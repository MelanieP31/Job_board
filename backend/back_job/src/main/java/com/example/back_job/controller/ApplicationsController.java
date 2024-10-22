package com.example.back_job.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.example.back_job.dto.ApplicationsDTO;
import com.example.back_job.entity.Applications;
import com.example.back_job.service.ApplicationsService;

@RestController
@CrossOrigin(origins = "http://localhost:5173")
@RequestMapping(value="/api", method= {RequestMethod.POST, RequestMethod.GET})
public class ApplicationsController {
	
	private ApplicationsService apService;
	
	@Autowired
	public ApplicationsController(ApplicationsService apService) {
		this.apService = apService;
	}
	
	@PostMapping(value = "/applications")
	public Applications applicationsSave(@RequestBody ApplicationsDTO appdto) {	
		return apService.applicationsSave(appdto);		
	}
	
	@GetMapping(value = "/getapplications")
	public List<ApplicationsDTO> getAllApplications(){
        return apService.getAllApplications();
	}
	
	@DeleteMapping(value = "/deleteapplication")
	public void deleteApplication(@RequestBody ApplicationsDTO appdto) {
		apService.deleteAppplications(appdto);	
	}
	

}


