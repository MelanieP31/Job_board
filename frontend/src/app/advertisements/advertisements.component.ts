import { Component, OnInit } from '@angular/core';
import { AdvertisementsCard } from '../model/advertisements-card';
import { AdvertisementsService } from '../service/advertisements.service';

@Component({
  selector: 'app-advertisements',
  templateUrl: './advertisements.component.html',
  styleUrl: './advertisements.component.css'
})
export class AdvertisementsComponent implements OnInit {
  advertisements : AdvertisementsCard[] = []

  isModalOpen : number | null = null;


  constructor(private advertisementService: AdvertisementsService) {}

  ngOnInit(): void {
      this.advertisementService.getAdvertisements().subscribe((advertisements) =>{
        this.advertisements = advertisements;
      });
  }

  //modal
  openModal(index: number){
    this.isModalOpen = index;
  }

  closeModal(){
    this.isModalOpen = null;
  }

}
