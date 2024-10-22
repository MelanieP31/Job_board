package com.example.back_job.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.back_job.entity.Advertisements;

@Repository
public interface AdvertisementsRepository extends JpaRepository <Advertisements, Integer> {
	
}
