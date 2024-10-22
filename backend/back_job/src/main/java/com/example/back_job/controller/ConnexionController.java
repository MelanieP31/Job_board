package com.example.back_job.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.example.back_job.dto.UserLoginDTO;
import com.example.back_job.service.UserServiceConnexion;


//Abandon du token, retour a la méthode simple, je vérifie il existe, elle fait un token session. 

@RestController
@CrossOrigin(origins = "http://localhost:5173")
@RequestMapping(value="/api/login", method= {RequestMethod.POST, RequestMethod.GET})
public class ConnexionController {
	
	private UserServiceConnexion userServiceConnexion;
	
	public ConnexionController (UserServiceConnexion userServiceConnexion) {
		this.userServiceConnexion = userServiceConnexion;
		
	}
	
	@PostMapping
	public ResponseEntity<String> login(@RequestBody UserLoginDTO userLoginDto){
		
		return userServiceConnexion.login(userLoginDto);
		
	}	

}
