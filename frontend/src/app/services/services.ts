import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Application, JobOffer } from '../modele/modele';

@Injectable({
  providedIn: 'root'
})
export class JobOfferService {

  private baseUrl = "http://localhost:5281/api";

  constructor(private http : HttpClient) { }

  //applications
  private applicationsUrl = this.baseUrl + "/applications"

  getApplications():Observable<Application[]>{
    return this.http.get<Application[]>(this.applicationsUrl);
  }
  
  getApplication(id : number):Observable<Application>{
    return this.http.get<Application>(this.applicationsUrl + `/${id}`);
  }

  createApplication(app :Application):Observable<Application>{
    return this.http.post<Application>(this.applicationsUrl, app);
  }

  updateApplicationStatus(status : string):Observable<Application>{
    return this.http.put<Application>(this.applicationsUrl, status);
  }

  private jobOfferUrl = this.baseUrl + "/joboffers"

  getJobOffer(): Observable<JobOffer[]> {
    return this.http.get<JobOffer[]>(this.jobOfferUrl);
  }
}
