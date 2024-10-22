package com.example.back_job.service;

import org.springframework.stereotype.Service;

import com.example.back_job.dto.UserDTO;
import com.example.back_job.entity.Users;

@Service
public class UserEntityConvertion {
	
	public Users convertUserToEntity(UserDTO userdto) {
		
		Users user = new Users();
		
		user.setUser_id(userdto.getUser_id());
		user.setFirst_name(userdto.getFirst_name());
		user.setLast_name(userdto.getLast_name());
		user.setEmail(userdto.getEmail());
		user.setPhone(userdto.getPhone());
		user.setPassword(userdto.getPassword());
		

		return user;
		
	}

}
