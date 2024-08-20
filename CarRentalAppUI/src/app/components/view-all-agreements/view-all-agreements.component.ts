import { Component, OnInit } from '@angular/core';
import { RentService } from 'src/app/shared/rent.service';

@Component({
  selector: 'app-view-all-agreements',
  templateUrl: './view-all-agreements.component.html',
  styleUrls: ['./view-all-agreements.component.css']
})
export class ViewAllAgreementsComponent implements OnInit {
  agreements: any;
  constructor(private rentservice: RentService){}
  ngOnInit(): void {
    this.getAllAgreement()
  }

  getAllAgreement(){
    this.rentservice.getAllAgreements()
    .subscribe({
      next:(res)=>{
        console.log(res);
        this.agreements=res;
      },
      error:(err)=>{
        alert("Error getting All Agreements: Server Error");
      }
    })
  }
  deleteAgreement(id:string){
    this.rentservice.deleteAgreement(id)
    .subscribe({
      next:(res)=>{
        alert(res.response);
        console.log(res);
        this.getAllAgreement();
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }
}
