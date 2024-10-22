package com.example.back_job.entity;

import java.sql.Date;
import java.util.Set;

import org.hibernate.annotations.CreationTimestamp;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;
import jakarta.persistence.Temporal;
import jakarta.persistence.TemporalType;
import lombok.Getter;
import lombok.Setter;

@Entity
@Table(name="advertisements")
@Getter
@Setter
public class Advertisements {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name="ad_id")
	private int  ad_id;
	
	@OneToMany(cascade = CascadeType.ALL, mappedBy = "advertisement") // 1 ad for multiple applications
	private Set<Applications> application;
	
	@ManyToOne // Multiple ad from 1 company.
	@JoinColumn(name="cmp_id")
	private Companies joboffer;
	
	@Column(name="title")
	private String title;
	
	@Column(name="short_description")	
	private String short_description;
	
	@Column(name="long_description")
	private String long_description;
	
	@Column(name="contract_type")	
	private String contract_type;
	
	@Column(name="salary")
	private int salary;
	
	@Column(name="creation_date")
	@CreationTimestamp
	@Temporal(TemporalType.DATE)
	private Date creation_date;


}
