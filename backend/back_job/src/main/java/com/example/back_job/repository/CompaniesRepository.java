package com.example.back_job.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.back_job.entity.Companies;

public interface CompaniesRepository extends JpaRepository<Companies, Integer>{

	
}
