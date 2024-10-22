package com.example.back_job.dto;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class UserDTO {
	private int user_id;
	private String last_name;
	private String first_name;
	private String email;
	private String phone;
	private String password;

}
