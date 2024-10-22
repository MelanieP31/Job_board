package com.example.back_job.service;

import java.util.ArrayList;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.back_job.dto.UserDTO;
import com.example.back_job.entity.Users;
import com.example.back_job.repository.UserRepository;

@Service
public class UserService {
	
	private UserRepository userRepository;
	
	//constructeur
	@Autowired
    public UserService(UserRepository userRepository) {
        this.userRepository= userRepository;
    }
	
	// Méthode GET : 
	//(GET) 1er etape remplir les DTO avec les bonnes info (celle des entité)	
	
	public UserDTO convertToUserDto(Users user) {
		
        UserDTO dto = new UserDTO();
        
        dto.setUser_id(user.getUser_id());
        dto.setLast_name(user.getLast_name());
        dto.setFirst_name(user.getFirst_name());        
        dto.setEmail(user.getEmail());             
        dto.setPhone(user.getPhone());
        
        return dto;
    }

	
	//(GET) 2eme etape : appliquer ce remplissage pour tout le monde : List (C'est le seul truc que je sais faire alors banco) initialisé list - boucle for
    public List<UserDTO> convertToUserDtoList(List<Users> users) {
    	
        List<UserDTO> dtoList = new ArrayList<>();
        
        for (Users user :users) {       	
        	UserDTO dto = convertToUserDto(user);      	
        	dtoList.add(dto);
        }
        
        return dtoList;
    }    

    //(GET) Méthode pour ensuite acceder a notre tout beau objet : 
	public List<UserDTO> getAllUsers() {
		List<Users> users = userRepository.findAll();
		return convertToUserDtoList(users);
	}
	
	
	
	//DELETE
	public void deleteUser(UserDTO userDto) {
		int user_id = userDto.getUser_id();
		userRepository.deleteById(user_id);
	}
	
}

