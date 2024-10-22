package com.example.back_job.repository;



import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.back_job.entity.Users;

@Repository
public interface UserRepository extends JpaRepository<Users, Integer> {

	Users findByEmail(String email);
	
	Users findByPassword(String password);

	Users findByEmailAndPassword(String email, String password);

	
	
}
