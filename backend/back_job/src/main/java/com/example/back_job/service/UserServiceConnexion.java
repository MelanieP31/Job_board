package com.example.back_job.service;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.example.back_job.dto.UserLoginDTO;
import com.example.back_job.entity.Users;
import com.example.back_job.repository.UserRepository;


// Verifier si email et mot de passe existe.

//New : ajouter les admins en dur

@Service
public class UserServiceConnexion {
	
	private UserRepository userRepository;
	
	@Autowired
	public UserServiceConnexion(UserRepository userRepository) {
		this.userRepository = userRepository;
	}
	
	public ResponseEntity<String> login(UserLoginDTO userLoginDto){
		
		if("admin@test.fr".equals(userLoginDto.getEmail()) && "admin".equals(userLoginDto.getPassword())) {
			return ResponseEntity.status(HttpStatus.ACCEPTED).body("Connexion as Administrator"); //202
		}
		
		Users user = userRepository.findByEmailAndPassword(userLoginDto.getEmail(),userLoginDto.getPassword());
		
		if(user != null) {	
		
			return ResponseEntity.status(HttpStatus.OK).body("Connexion ok"); //200	
		
		} else {
		
			return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Email or password incorrect");
		}
	}
	
}
