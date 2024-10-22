package com.example.back_job.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.back_job.dto.ApplicationsDTO;
import com.example.back_job.dto.UserDTO;
import com.example.back_job.entity.Advertisements;
import com.example.back_job.entity.Applications;
import com.example.back_job.entity.Users;
import com.example.back_job.repository.AdvertisementsRepository;
import com.example.back_job.repository.ApplicationsRepository;
import com.example.back_job.repository.UserRepository;

@Service
public class ApplicationsService {
	
	private ApplicationsRepository apRepository;
	private UserRepository userRepository;
	private AdvertisementsRepository adRepository;
	
	private UserEntityConvertion userEntityConvert;
	
	@Autowired
    public ApplicationsService(ApplicationsRepository apRepository, UserRepository userRepository, AdvertisementsRepository adRepository, UserEntityConvertion userEntityConvert) {
        this.apRepository = apRepository;
        this.userRepository = userRepository;
        this.adRepository = adRepository;
        this.userEntityConvert = userEntityConvert;
    }	
	
	//POST : 
	//(POST) 1 : Fill entity with DTO
	public Applications convertApplicationsToEntity(ApplicationsDTO appdto) {
		
	    Applications ap = new Applications();

	    ap.setApplication_id(appdto.getApplication_id());
	    ap.setMessage(appdto.getMessage());

	    // Vérifier que l'objet UserDTO n'est pas nul
	    if (appdto.getUsers() != null) {
	    	
	        ap.setCandidat(userEntityConvert.convertUserToEntity(appdto.getUsers())); 
	        
	    } else {
	    	
	        throw new IllegalArgumentException("UserDTO cannot be null");
	    }

	    Advertisements advertisement = adRepository.findById(appdto.getAdvertisement_id()).orElse(null);
	    ap.setAdvertisement(advertisement);

	    return ap;
	}
		
	//(POST) 2 : Save application in database (controller method)
	//Save dans le Repository
	public Applications applicationsSave(ApplicationsDTO appdto) {
		
		//Recup l'application
		Applications app = convertApplicationsToEntity(appdto);	
		
		//Recup l'id du candidat
		Users user = app.getCandidat();
		//Recup le mail associé à cet id
		Users candidatMail = userRepository.findByEmail(user.getEmail());
		
		//si le mail est null
		if(candidatMail == null) {
			userRepository.save(user); //alors sauvegarder le nouvel pseudo-inscrit
		}else {
			app.setCandidat(user); // Sinon dans l'app ajouter l'id du candidat
		}
		
		return apRepository.save(app); //Sauvegarder l'offre dans la BDD
	}
	
	
	
	//GET :	
	//(GET) 1 :Fill UserDTO with Entity
	public UserDTO convertUserToDto(Users user) {
		
		UserDTO userDto = new UserDTO();
					
		userDto.setUser_id(user.getUser_id());
		userDto.setFirst_name(user.getFirst_name());
		userDto.setLast_name(user.getLast_name());
		userDto.setEmail(user.getEmail());
		userDto.setPhone(user.getPhone());
		userDto.setPassword(user.getPassword());
		

		return userDto;
		
	}

	//(GET) 2 : Fill ApplicationDTO with Entity (and User link)
	public ApplicationsDTO convertApplicationToDto(Applications app) {
		
		ApplicationsDTO appDTO = new ApplicationsDTO(); 
		
		appDTO.setApplication_id(app.getApplication_id());
		appDTO.setApplication_date(app.getApplication_date());
		appDTO.setMessage(app.getMessage());
		
		 if (app.getCandidat() != null) {
		    	
		        appDTO.setUsers(convertUserToDto(app.getCandidat())); 
		        
		    } else {
		    	
		        throw new IllegalArgumentException("UserDTO cannot be null");
		    }
		
		
		return appDTO;
		
	}
	
	//(GET) 3 : Apply for all
	public List<ApplicationsDTO> convertToApplicationDtoList(List<Applications> apps) {
	    	
	        List<ApplicationsDTO> dtoList = new ArrayList<>();
	        
	        for (Applications app :apps) { 
	        	
	        	ApplicationsDTO dto = convertApplicationToDto(app);      	
	        	dtoList.add(dto);
	        }
	        
	        return dtoList;
	    }
	 
	//(GET) 4 : Send (controller method)
	public List<ApplicationsDTO> getAllApplications() {
		 
			List<Applications> apps = apRepository.findAll();
			
			return convertToApplicationDtoList(apps);
		}
	
	
	public void deleteAppplications(ApplicationsDTO appDto) {
		int app_id = appDto.getApplication_id();
		apRepository.deleteById(app_id);
	}
	    
	
}