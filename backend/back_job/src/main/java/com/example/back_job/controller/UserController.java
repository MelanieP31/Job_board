package com.example.back_job.controller;

import java.util.List;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.example.back_job.dto.UserDTO;
import com.example.back_job.service.UserService;
import com.example.back_job.service.UserServiceInscription;

@RestController
@CrossOrigin(origins = "http://localhost:5173")
@RequestMapping(value="/api", method= {RequestMethod.POST, RequestMethod.GET})
public class UserController {
	
	private UserServiceInscription userInscriptionService;
	private UserService userService;
	
	public UserController (UserServiceInscription userInscriptionService, UserService userService) {
		this.userInscriptionService = userInscriptionService;
		this.userService = userService;
	}
	
	@PostMapping(value = "/register")
	public ResponseEntity<String> usersInscriptions(@RequestBody UserDTO userdto){
		return userInscriptionService.usersInscription(userdto);
		
	}
	
	@GetMapping(value= "/users")
    public List<UserDTO> getAllUsers(){
        return userService.getAllUsers();
	}
	
	
	//https://medium.com/@chandantechie/spring-boot-application-with-crud-operations-using-spring-data-jpa-and-mysql-23c8019660b1
	@DeleteMapping(value = "/deleteuser")
	public void deleteUser(@RequestBody UserDTO userdto) {
		userService.deleteUser(userdto);	
	}
	

}
