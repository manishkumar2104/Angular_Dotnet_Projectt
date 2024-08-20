import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/shared/car.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {

  cars:any =[];
  areCarAvailable:boolean= true;
  constructor(private carService: CarService){}

  ngOnInit(): void {
    this.getAllCars();
  }
  getAllCars(){
    this.carService.getAllCars()
    .subscribe({
      next:(res)=>{
        this.cars= res;
      },
      error:(err)=>{
        this.areCarAvailable= false;
      }
    });
  }

  deleteCar(id:string){
    this.carService.deleteCar(id)
    .subscribe({
      next:(res)=>{
        alert('Deleted Successfully');
        this.getAllCars();
      },
      error:(err)=>{
        alert("Server Error occured Deleting the car");
      }
    })
  }

}
