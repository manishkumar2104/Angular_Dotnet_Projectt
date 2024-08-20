import { Component, OnInit } from '@angular/core';
import { RentService } from 'src/app/shared/rent.service';

@Component({
  selector: 'app-user-agreements',
  templateUrl: './user-agreements.component.html',
  styleUrls: ['./user-agreements.component.css']
})
export class UserAgreementsComponent implements OnInit {
  agreements:any;
  constructor(private rentService: RentService){}
  ngOnInit(): void {
    this.getuserAgreements();
  }

  getuserAgreements(){
    this.rentService.getUserAgreement()
    .subscribe({
      next:(res)=>{
        this.agreements=res;
        console.log(this.agreements)
      }
    })
  }
}
