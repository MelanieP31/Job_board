package com.example.back_job.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.back_job.dto.AdvertisementDTO;
import com.example.back_job.entity.Advertisements;
import com.example.back_job.service.AdvertisementService;

@RestController
@CrossOrigin(origins = "http://localhost:5173")
@RequestMapping("/api")
public class AdvertisementsController {
	
	private AdvertisementService adService;
	
	//constructor
	@Autowired
    public AdvertisementsController(AdvertisementService adService) {
    	this.adService = adService;
    }
	
	@GetMapping(value = "/advertisements")
    public List<AdvertisementDTO> getAllAdvertisements(){
        return adService.getAllAdvertisements();
	}
	
	@PostMapping(value = "/postadvertisements")
	public Advertisements saveAdvertisement(@RequestBody AdvertisementDTO adDto){
		return adService.saveAdvertisement(adDto);
	}
	
	@DeleteMapping(value = "/deleteadvertisement")
	public void deleteAdvertisement(@RequestBody AdvertisementDTO addto) {
		adService.deleteAdvertisement(addto);	
	}

}
