package com.example.back_job.service;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.example.back_job.dto.UserDTO;
import com.example.back_job.entity.Users;
import com.example.back_job.repository.UserRepository;

@Service
public class UserServiceInscription {
	
	private UserRepository userRepository;	
	private UserEntityConvertion userEntityConvert;
	
    public UserServiceInscription(UserRepository userRepository, UserEntityConvertion userEntityConvert) {
        this.userRepository = userRepository;
        this.userEntityConvert = userEntityConvert;
    }
	
	public ResponseEntity<String> usersInscription(UserDTO userdto) {
		
		Users user = userEntityConvert.convertUserToEntity(userdto);
		Users userByEmail = userRepository.findByEmail(user.getEmail());
		
		if (userByEmail != null) {
			
			String password = userByEmail.getPassword();
			
			if (password != null) {
				
				return ResponseEntity.status(HttpStatus.CONFLICT).body("This user already have an inscription, email already used");
				
			} else {
				//2 possibilités :
				// Reset only password but : if somethong else change (for whatever raison) ?
				// Resave the entire application for inscription (prob il peut y avoir dans la bdd plein de fois la meme adresse mail)				
				userRepository.save(user);
				return ResponseEntity.status(HttpStatus.ACCEPTED).body("This user has been register");
				
			}
	
		} else {
				
			userRepository.save(user);		
			return ResponseEntity.status(HttpStatus.OK).body("This user has been register");	
			
		}
		
	}

}
