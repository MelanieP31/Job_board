package com.example.back_job.entity;

import java.util.Set;

import com.fasterxml.jackson.annotation.JsonIdentityInfo;
import com.fasterxml.jackson.annotation.ObjectIdGenerators;

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

@Entity
@Table(name="companies")
@Getter
@Setter
@JsonIdentityInfo(
		generator = ObjectIdGenerators.PropertyGenerator.class,
		property = "cmp_id")
public class Companies {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name="cmp_id")
	private int cmp_id;
	
	@OneToMany(cascade = CascadeType.ALL, mappedBy="joboffer") // Une companie multiple ad
	private Set<Advertisements> advertisement;
	
	@Column(name="name")	
	private String name;
	
	@Column(name="email")	
	private String email;
	
	@Column(name="description")
	private String description;
	
	@Column(name="location")	
	private String location; 
}
