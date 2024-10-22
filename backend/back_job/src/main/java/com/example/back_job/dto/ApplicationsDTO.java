package com.example.back_job.dto;

import java.sql.Date;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class ApplicationsDTO {
	private int application_id;
	private String message;
	private Date application_date;
	
	private UserDTO users;
	private int advertisement_id;

}
