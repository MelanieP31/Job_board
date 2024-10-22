package com.example.back_job.service;

import java.util.ArrayList;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.example.back_job.dto.AdvertisementDTO;
import com.example.back_job.entity.Advertisements;
import com.example.back_job.entity.Companies;
import com.example.back_job.repository.AdvertisementsRepository;
import com.example.back_job.repository.CompaniesRepository;

@Service
public class AdvertisementService {
	
	private AdvertisementsRepository adRepository;
	private CompaniesRepository cmpRepository;
	
	@Autowired
    public AdvertisementService(AdvertisementsRepository adRepository, CompaniesRepository cmpRepository) {
        this.adRepository = adRepository;
        this.cmpRepository = cmpRepository;
    }
	
	//GET
	//(GET) : 1 - fill DTO with Entity's data.
	public AdvertisementDTO convertToAdvertisementDto(Advertisements ad) {
		
        AdvertisementDTO dto = new AdvertisementDTO();
        
        dto.setAd_id(ad.getAd_id());
        dto.setTitle(ad.getTitle());
        dto.setShort_description(ad.getShort_description());        
        dto.setLong_description(ad.getLong_description());             
        dto.setContract_type(ad.getContract_type());
        dto.setSalary(ad.getSalary());
        dto.setCreation_date(ad.getCreation_date());
        

        
        return dto;
    }

	
	//(GET) : 2 - Apply for all Applications
    public List<AdvertisementDTO> convertToAdvertisementDtoList(List<Advertisements> ads) {
    	
        List<AdvertisementDTO> dtoList = new ArrayList<>();
        
        for (Advertisements ad :ads) {       	
        	AdvertisementDTO dto = convertToAdvertisementDto(ad);      	
        	dtoList.add(dto);
        }
        
        return dtoList;
    }
    
    //(GET) : 3 - Final : the function to call in the controller 
	public List<AdvertisementDTO> getAllAdvertisements() {
		List<Advertisements> ads = adRepository.findAll();
		return convertToAdvertisementDtoList(ads);
	}

	
	//POST
	//(POST) From DTO to Entity
	public Advertisements convertAdvertisementToEntity(AdvertisementDTO addto) {
		
	    Advertisements ad = new Advertisements();

	    ad.setAd_id(addto.getAd_id());
	    ad.setTitle(addto.getTitle());
	    ad.setShort_description(addto.getShort_description());
	    ad.setLong_description(addto.getLong_description());
	    ad.setContract_type(addto.getContract_type());
	    ad.setSalary(addto.getSalary());
	    
        Companies companie = cmpRepository.findById(addto.getCmp_id()).orElse(null);
	    ad.setJoboffer(companie);

	    return ad;
	}
	
	//(POST) Save dans la bdd
	public Advertisements saveAdvertisement (AdvertisementDTO addto){
		
		Advertisements advertisement = convertAdvertisementToEntity(addto);
		
		ResponseEntity.status(HttpStatus.OK).body("New advertisement register!");
		return adRepository.save(advertisement);
	}
	
	
	//DELETE
	public void deleteAdvertisement(AdvertisementDTO addto) {
		int ad_id = addto.getAd_id();
		adRepository.deleteById(ad_id);
	}
}

