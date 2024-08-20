import { Component, OnInit } from '@angular/core';
import {  FormControl, FormGroup, Validators, FormBuilder } from "@angular/forms";
import { CarService } from 'src/app/shared/car.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  availableCars : any = [];
  areCarAvailable:boolean= true;
  isSearchCriteriaFilled:boolean= false;
  constructor(private carService: CarService, private fb: FormBuilder ){}
  searchFilter = new FormGroup({
    maker: new FormControl(''),
    model: new FormControl(''),
    rent: new FormControl('')
  })

  ngOnInit(): void {
    this.getAvailableCars();
    this.searchFilter.valueChanges.subscribe(()=>{
      this.searchCriteriaFilled();
    })
    this.searchCriteriaFilled();
  } 
  getAvailableCars(){
    this.carService.getAvailableCars()
    .subscribe({
      next:(res)=>{
        this.availableCars= res
        if(this.availableCars.length==0){
          this.areCarAvailable= false;
        }
      },
      error:(err)=>{
        alert("Server Error Occured")
        this.areCarAvailable=false;
      }
    })
  }
  searchCriteriaFilled(){
    return this.searchFilter.value.maker||this.searchFilter.value.model||this.searchFilter.value.rent;
  }
  searchCar(){

    this.carService.getFilteredCars(this.searchFilter.value.maker!, this.searchFilter.value.model!, this.searchFilter.value.rent!)
    .subscribe({
      next:(res)=>{
        this.availableCars= res;
      }
    })
    alert('searching cars according to filter')
  }

  get maker(){
    return this.searchFilter.get('maker');
  }
  get model(){
    return this.searchFilter.get('model');
  }
  get rent(){
    return this.searchFilter.get('rent');
  }
}
