import { Component, OnInit } from '@angular/core';
import { validateRequestModel } from 'src/app/models/validateReturnRequestModel';
import { RentService } from 'src/app/shared/rent.service';

@Component({
  selector: 'app-view-return-request',
  templateUrl: './view-return-request.component.html',
  styleUrls: ['./view-return-request.component.css']
})
export class ViewReturnRequestComponent implements OnInit {
  agreements: any;
  requestData:validateRequestModel = {agreementId: '', isAccepted: false}
  constructor(private rentservice: RentService){}
  ngOnInit(): void {
    this.getAllReturnRequestAgreements()
  }

  getAllReturnRequestAgreements(){
    this.rentservice.getAllReturnRequestAgreements()
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

  acceptReturnRequest(id:string){
    this.requestData.agreementId=id;
    this.requestData.isAccepted= true;
    this.rentservice.validateReturnRequest(this.requestData)
    .subscribe({
      next:(res)=>{
        alert("Request Accepted Successfully");
        console.log(res);
        this.getAllReturnRequestAgreements();
      }
    })
  }
  rejectReturnRequest(id:string){
    this.requestData.agreementId= id;
    this.requestData.isAccepted= false;
    this.rentservice.validateReturnRequest(this.requestData)
    .subscribe({
      next:(res)=>{
        alert("Request Rejected Successfully");
        console.log(res);
        this.getAllReturnRequestAgreements();
      }
    })
  }
}
