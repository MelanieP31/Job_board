package com.example.back_job.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.back_job.entity.Applications;

public interface ApplicationsRepository extends JpaRepository<Applications, Integer> {

}
