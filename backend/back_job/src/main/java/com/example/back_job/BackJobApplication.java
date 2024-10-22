package com.example.back_job;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.security.servlet.SecurityAutoConfiguration;

@SpringBootApplication(exclude = {SecurityAutoConfiguration.class})
public class BackJobApplication {

	public static void main(String[] args) {
		SpringApplication.run(BackJobApplication.class, args);
	}

}
