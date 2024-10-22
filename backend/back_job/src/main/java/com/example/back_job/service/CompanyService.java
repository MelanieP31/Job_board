package com.example.back_job.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.example.back_job.dto.CompanyDTO;
import com.example.back_job.entity.Companies;
import com.example.back_job.repository.CompaniesRepository;

@Service
public class CompanyService {

	private CompaniesRepository cmpRepository;
	
	@Autowired
    public CompanyService(CompaniesRepository cmpRepository) {
        this.cmpRepository = cmpRepository;
    }
	
	//GET
	//(GET) - 1 fill DTO with Entity	
	public CompanyDTO convertToCompanyDto(Companies cmp) {
		
        CompanyDTO dto = new CompanyDTO();
        
        dto.setCmp_id(cmp.getCmp_id());
        dto.setName(cmp.getName());
        dto.setEmail(cmp.getEmail());        
        dto.setDescription(cmp.getDescription());             
        dto.setLocation(cmp.getLocation());
        
        return dto;
    }
	
	//(GET) - 2 apply for all companies
    public List<CompanyDTO> convertToCompanyDtoList(List<Companies> cmps) {
    	
        List<CompanyDTO> dtoList = new ArrayList<>();
        
        for (Companies cmp :cmps) {       	
        	CompanyDTO dto = convertToCompanyDto(cmp);      	
        	dtoList.add(dto);
        }
        
        return dtoList;
    }
    
    //(GET) - 3 Get all (Controller method) 
	public List<CompanyDTO> getAllCompanies() {
		List<Companies> cmps = cmpRepository.findAll();
		return convertToCompanyDtoList(cmps);
	}
	
	//POST
	//(POST) From DTO to Entity
	public Companies convertCompanyToEntity(CompanyDTO cmpdto) {
		
	    Companies cmp = new Companies();

	    cmp.setName(cmpdto.getName());
	    cmp.setEmail(cmpdto.getEmail());
	    cmp.setLocation(cmpdto.getLocation());
	    cmp.setDescription(cmpdto.getDescription());

	    return cmp;
	}
	
	//(POST) Save in database
	public Companies saveCompany (CompanyDTO companydto){
		Companies companie = convertCompanyToEntity(companydto);
		
		ResponseEntity.status(HttpStatus.OK).body("New company register! ");
		
		return cmpRepository.save(companie);
	}
	
	//DELETE
	public void deleteCompany(CompanyDTO cmpDto) {
		int cmp_id = cmpDto.getCmp_id();
		cmpRepository.deleteById(cmp_id);
	}

}

