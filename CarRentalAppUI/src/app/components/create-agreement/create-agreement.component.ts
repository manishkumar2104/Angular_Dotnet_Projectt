import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AgreementModel } from 'src/app/models/agreement';
import { AuthService } from 'src/app/shared/auth.service';
import { CarService } from 'src/app/shared/car.service';
import { RentService } from 'src/app/shared/rent.service';

@Component({
  selector: 'app-create-agreement',
  templateUrl: './create-agreement.component.html',
  styleUrls: ['./create-agreement.component.css']
})
export class CreateAgreementComponent implements OnInit {
  car:any;
  userDetail:any;
  id:string= '';
  duration:number= 0;
  agreementDetail:AgreementModel={CarId:'', Duration: 1, TotalCost:1000};
  constructor(private router: Router, private carService: CarService, private route: ActivatedRoute, private authService: AuthService, private rentService: RentService){}
  ngOnInit(): void {
    this.route.params.subscribe(params=>{
      this.id= params['carId'],
      this.duration= params['duration']
    })
    this.carService.getCarDetail(this.id)
    .subscribe({
      next:(res)=>{
        this.car= res;
        this.getUserDetail();
      }
    })
  }

  getUserDetail(){
    this.authService.getUserData()
    .subscribe({
      next:(res)=>{
        this.userDetail= res.userData;
      }
    })
  }
  createAgreement(){
    this.agreementDetail.CarId= this.car.id;
    this.agreementDetail.Duration= this.duration;
    this.agreementDetail.TotalCost= this.car.rentalPrice* this.duration;
    console.log(this.agreementDetail);
    this.rentService.addAgreement(this.agreementDetail)
    .subscribe({
      next:(res)=>{
        alert(res.message);
        this.router.navigate(['/dashboard']);
      },
      error:(err)=>{
        alert("Error Occured");
      }
    })
  }
}
