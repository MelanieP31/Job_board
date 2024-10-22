package com.example.back_job.controller;

import java.util.List;

import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.example.back_job.dto.CompanyDTO;
import com.example.back_job.entity.Companies;
import com.example.back_job.service.CompanyService;

@RestController
@CrossOrigin(origins = "http://localhost:5173")
@RequestMapping(value="/api", method= {RequestMethod.POST, RequestMethod.GET})
public class CompaniesController {
	
	private CompanyService companyService;
	
	public CompaniesController(CompanyService companyService) {
		this.companyService = companyService; 
		
	}
	
	@GetMapping(value = "/getcompany")
	public List<CompanyDTO> getAllCompanies(){
        return companyService.getAllCompanies();
	}
	
	@PostMapping(value = "/postcompany")
	public Companies saveCompany(@RequestBody CompanyDTO cmpDto){
		return companyService.saveCompany(cmpDto);
	}
	
	@DeleteMapping(value = "/deletecompany")
	public void deleteCompany(@RequestBody CompanyDTO cmpdto) {
		companyService.deleteCompany(cmpdto);	
	}
}
