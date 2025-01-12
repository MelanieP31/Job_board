import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JobOffer } from '../modele/job-offer';

@Injectable({
  providedIn: 'root'
})
export class JobOfferService {

  private baseUrl = "http://localhost:5281/api";

  constructor(private http : HttpClient) { }

  private jobOfferUrl = this.baseUrl + "/joboffers"

  getJobOffer(): Observable<JobOffer[]> {
    return this.http.get<JobOffer[]>(this.jobOfferUrl);
  }
}
