import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AdvertisementsCard } from '../model/advertisements-card';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AdvertisementsService {

  private baseUrl = 'http://localhost:8080/api'

  constructor(private http : HttpClient) { }

  getAdvertisements(): Observable<AdvertisementsCard[]>{
    return this.http.get<AdvertisementsCard[]>(`${this.baseUrl}/advertisements`);
  }
}
