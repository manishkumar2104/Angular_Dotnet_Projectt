import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CarModel } from 'src/app/models/postBookData';
import { CarService } from 'src/app/shared/car.service';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent {

  constructor(private carService:CarService, private route: Router){}

  addedCarDetails: CarModel= {maker: '', model: '', rentalPrice: 0, imageUrl: ''};
  addCarForm= new FormGroup({
    maker: new FormControl('',[Validators.required, Validators.minLength(2)]),
    model: new FormControl('', [Validators.required, Validators.minLength(2)]),
    rentalPrice: new FormControl('', [Validators.required, Validators.min(1000)]),
    imageUrl: new FormControl('', [Validators.required, Validators.minLength(10)])
  })

  addCar(){
    this.addedCarDetails.maker= this.addCarForm.value.maker!.toString();
    this.addedCarDetails.model= this.addCarForm.value.model!.toString();
    this.addedCarDetails.rentalPrice= parseInt(this.addCarForm.value.rentalPrice!.toString());
    this.addedCarDetails.imageUrl = this.addCarForm.value.imageUrl!.toString();
    this.carService.addCar(this.addedCarDetails)
    .subscribe({
      next:(res)=>{
        alert(res.message);
        this.route.navigate(['/adminDashboard']);
      },
      error:(err)=>{
        alert("Server Error occured ")
      }
    })
  }

  get maker(){
    return this.addCarForm.get('maker');
  }

  get model(){
    return this.addCarForm.get('model');
  }

  get rentalPrice(){
    return this.addCarForm.get('rentalPrice');
  }

  get imageUrl(){
    return this.addCarForm.get('imageUrl');
  }
}
