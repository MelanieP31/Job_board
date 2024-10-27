package com.example.back_job.dto;

import java.sql.Date;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class AdvertisementDTO {
	
	private int ad_id;
	private String title;
    private String short_description;
    private String long_description;
    private String contract_type;
    private int salary;
    private int cmp_id;
    private Date creation_date;

}
