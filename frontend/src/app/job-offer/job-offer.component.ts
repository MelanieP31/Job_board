import { Component } from '@angular/core';
import { JobOffer } from '../modele/job-offer';
import { JobOfferService } from '../services/job-offer.service';

@Component({
  selector: 'app-job-offer',
  templateUrl: './job-offer.component.html',
  styleUrls: ['./job-offer.component.css']
})
export class JobOfferComponent {

  JobOffers : JobOffer[] = [];

  constructor(private JobOfferService : JobOfferService ) {}

  ngOnInit(): void {
    this.getAllJobOffer();
  }

  getAllJobOffer() : void {
    this.JobOfferService.getJobOffer().subscribe(
      (data) => {
        this.JobOffers = data;
      },
      (error) => { 
        console.error("error getAll JobOffer : ", error); 
      }
    );
  }



}
