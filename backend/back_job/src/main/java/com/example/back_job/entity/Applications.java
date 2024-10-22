package com.example.back_job.entity;

import java.sql.Date;

import org.hibernate.annotations.CreationTimestamp;

import com.fasterxml.jackson.annotation.JsonIdentityInfo;
import com.fasterxml.jackson.annotation.ObjectIdGenerators;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;
import jakarta.persistence.Temporal;
import jakarta.persistence.TemporalType;
import lombok.Getter;
import lombok.Setter;

@Entity
@Table(name="application")
@Getter
@Setter
@JsonIdentityInfo(
		generator = ObjectIdGenerators.PropertyGenerator.class,
		property = "application_id")
public class Applications {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name="application_id")
	private int application_id;
	
	@ManyToOne // Multiple applications belong 1 offer.
	@JoinColumn(name="ad_id")
	private Advertisements advertisement;
	
	@ManyToOne // Multiple application from 1 user.
	@JoinColumn(name="user_id")
	private Users candidat;
	
	@Column(name="application_date")
	@CreationTimestamp
	@Temporal(TemporalType.DATE)
	private Date application_date;
	
	@Column(name="message")	
	private String message;


}
