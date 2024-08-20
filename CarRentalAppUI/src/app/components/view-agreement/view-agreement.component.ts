import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';
import { CarService } from 'src/app/shared/car.service';
import { RentService } from 'src/app/shared/rent.service';

@Component({
  selector: 'app-view-agreement',
  templateUrl: './view-agreement.component.html',
  styleUrls: ['./view-agreement.component.css']
})
export class ViewAgreementComponent implements OnInit{
  carId:string='';
  agreementId:string='';
  agreement: any;
  carDetail: any;
  userDetail:any;
  isActionPerformedByAdminOnReturnRequest:boolean= false;
  constructor(private route: ActivatedRoute, private router: Router, private rentService: RentService, private carService:CarService, private authService: AuthService){  }

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
        if(this.agreement.isReturnRequestAcceptedByAdmin!=null){
          this.isActionPerformedByAdminOnReturnRequest= true;
        }
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

  requestReturn(){
    this.rentService.requestReturn(this.agreement.id)
    .subscribe({
      next:(res)=>{
        alert(res.response)
        console.log(res);
        this.router.navigate(['/userAgreements'])
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }
}
