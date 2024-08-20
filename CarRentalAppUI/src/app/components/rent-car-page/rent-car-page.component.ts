import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from 'src/app/shared/car.service';

@Component({
  selector: 'app-rent-car-page',
  templateUrl: './rent-car-page.component.html',
  styleUrls: ['./rent-car-page.component.css']
})
export class RentCarPageComponent implements OnInit {
  car:any;
  id:string= '';
  constructor(private router: Router, private carService: CarService, private route: ActivatedRoute){}
  rentCarForm= new FormGroup({
    duration: new FormControl('', [Validators.required, Validators.min(1)])
  })
  ngOnInit(): void {
    this.route.params.subscribe(params=>{
      this.id= params['carId']
    })
    this.carService.getCarDetail(this.id)
    .subscribe({
      next:(res)=>{
        this.car= res;
      }
    })
  }
  get duration(){
    return this.rentCarForm.get('duration');
  }
  
}
