import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AgreementModel } from 'src/app/models/agreement';
import { updateAgreementModel } from 'src/app/models/updateAgreement';
import { AuthService } from 'src/app/shared/auth.service';
import { CarService } from 'src/app/shared/car.service';
import { RentService } from 'src/app/shared/rent.service';

@Component({
  selector: 'app-update-agreement',
  templateUrl: './update-agreement.component.html',
  styleUrls: ['./update-agreement.component.css']
})
export class UpdateAgreementComponent implements OnInit {
  carId:string='';
  agreementId:string='';
  agreement: any;
  carDetail: any;
  userDetail:any;
  updatedAgreementDetail:updateAgreementModel={Id:'',CarId:'', UserId:'', Duration: 1, TotalCost:1000};
  constructor(private route: ActivatedRoute, private router: Router, private carService: CarService, private authService:AuthService, private rentService:RentService){}
  ngOnInit(): void {
    this.route.params.subscribe(params=>{
      this.agreementId= params['agreementId']
    });
    this.rentService.getAgreementById(this.agreementId)
    .subscribe({
      next:(res)=>{
        console.log(res);
        this.agreement=res;
        this.carId= this.agreement.carId;
        this.getCarDetail();
      }
    })
  }
  getCarDetail(){
    this.carService.getCarDetail(this.carId)
    .subscribe({
      next:(res)=>{
        this.carDetail= res;
        console.log(this.carDetail);
        
        this.getUserDetail();
      }
    })
  }

  getUserDetail(){
    this.authService.getUserData()
    .subscribe({
      next:(res)=>{
        console.log(res.userData);
        this.userDetail= res.userData;
      }
    })
  }
  
  updateRentCarForm= new FormGroup({
    duration: new FormControl(1, [Validators.required, Validators.min(1)])
  })

  updateAgreement(){
    this.updatedAgreementDetail.Id= this.agreementId;
    this.updatedAgreementDetail.CarId= this.carId;
    this.updatedAgreementDetail.UserId= this.agreement.userId;
    this.updatedAgreementDetail.Duration= parseInt(this.updateRentCarForm.value.duration!.toString());
    this.updatedAgreementDetail.TotalCost= this.carDetail.rentalPrice*this.updatedAgreementDetail.Duration;   
    console.log(this.updatedAgreementDetail);
    this.rentService.updateAgreement(this.updatedAgreementDetail)
    .subscribe({
      next:(res)=>{
        alert("updated successfully");
        console.log(res);
        this.router.navigate(['/viewAllAgreement']);
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }


  get duration(){
    return this.updateRentCarForm.get('duration');
  }
}
