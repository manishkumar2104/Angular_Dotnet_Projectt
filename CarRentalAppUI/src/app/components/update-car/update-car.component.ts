import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CarModel } from 'src/app/models/postBookData';
import { CarService } from 'src/app/shared/car.service';

@Component({
  selector: 'app-update-car',
  templateUrl: './update-car.component.html',
  styleUrls: ['./update-car.component.css']
})
export class UpdateCarComponent implements OnInit {
  car:any;
  updatedCarDetails: CarModel= {maker: '', model: '', rentalPrice: 0, imageUrl: ''};
  updateCarForm= new FormGroup({
    maker: new FormControl('',[Validators.required, Validators.minLength(2)]),
    model: new FormControl('', [Validators.required, Validators.minLength(2)]),
    rentalPrice: new FormControl('', [Validators.required, Validators.min(1000)]),
    imageUrl: new FormControl('', [Validators.required, Validators.minLength(10)])
  })
  id:string='';
  constructor(private carService: CarService, private route: ActivatedRoute, private router: Router){}
  ngOnInit(): void {
    this.route.params.subscribe(params=>{
      this.id= params['carId']
    })
    this.carService.getCarDetail(this.id)
    .subscribe({
      next:(res)=>{
        this.car= res;
        console.log(this.car);
        this.updateCarForm.patchValue({
          maker: this.car.maker,
          model: this.car.model,
          rentalPrice: this.car.rentalPrice,
          imageUrl: this.car.imageUrl
        })
      }
    })
    
  }

  updateCar(){
    // console.log(this.updateCarForm.value);
    
    this.updatedCarDetails.maker= this.updateCarForm.value.maker!.toString();
    this.updatedCarDetails.model= this.updateCarForm.value.model!.toString();
    this.updatedCarDetails.rentalPrice= parseInt(this.updateCarForm.value.rentalPrice!.toString());
    this.updatedCarDetails.imageUrl = this.updateCarForm.value.imageUrl!.toString();
    // console.log(this.updatedCarDetails);
    this.carService.updateCar(this.id, this.updatedCarDetails)
    .subscribe({
      next:(res)=>{
        alert(res.message);
        console.log(res);
        this.router.navigate(['/adminDashboard']);
      }
    })
  }

  get maker(){
    return this.updateCarForm.get('maker');
  }

  get model(){
    return this.updateCarForm.get('model');
  }

  get rentalPrice(){
    return this.updateCarForm.get('rentalPrice');
  }

  get imageUrl(){
    return this.updateCarForm.get('imageUrl');
  }
}
