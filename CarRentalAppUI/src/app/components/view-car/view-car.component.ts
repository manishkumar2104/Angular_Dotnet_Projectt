import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CarService } from 'src/app/shared/car.service';

@Component({
  selector: 'app-view-car',
  templateUrl: './view-car.component.html',
  styleUrls: ['./view-car.component.css']
})
export class ViewCarComponent implements OnInit {

  car:any;
  id:string= '';
  constructor(private router: Router, private carService: CarService, private route: ActivatedRoute){}
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
}
