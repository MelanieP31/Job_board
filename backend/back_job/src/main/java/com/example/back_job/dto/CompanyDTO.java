package com.example.back_job.dto;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class CompanyDTO {
	private int cmp_id;
	private String name;
	private String email;
	private String description;
	private String location;

}
