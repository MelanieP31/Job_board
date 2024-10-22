package com.example.back_job.entity;

import java.util.Set;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
@Entity
@Table(name="users")
public class Users {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY) //IDENTITY : Correspond a une génération automatique par le auto-incremente de SQL - OK avec multiple classe lié entre elles.
	@Column(name="user_id")
	private int user_id;
	
	@OneToMany(cascade = CascadeType.ALL, mappedBy = "candidat") //Un candidat plusieurs application
	private Set<Applications> application;
	
	@Column(name="last_name")	
	private String last_name;
	
	@Column(name="first_name")
	private String first_name;
	
	@Column(name="email")
	private String email;
	
	@Column(name="phone")
	private String phone;
	
	@Column(name="description")
	private String description;
	
	@Column(name="password")
	private String password;

}

