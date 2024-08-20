import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CarModel } from '../models/postBookData';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  private baseUrl: string = "https://localhost:7198/api/Car/"
  constructor(private http: HttpClient) { }
  getAvailableCars(){
    return this.http.get<any>(this.baseUrl + 'GetAvailableCars');
  }

  getFilteredCars(maker?:string, model?:string, rentalPrice?:string){
    if(!rentalPrice){
      return this.http.get<any>(this.baseUrl + `getFilteredCars?Maker=${maker ?? ''}&Model=${model??''}`);
    }
    else{
      var rentPrice= parseInt(rentalPrice);
      return this.http.get<any>(this.baseUrl + `getFilteredCars?Maker=${maker ?? ''}&Model=${model??''}&RentalPrice=${rentPrice}`);
    }
    
  }

  getAllCars(){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.get<any>(this.baseUrl+ 'getAllCars', {headers});
  }

  deleteCar(id:string){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.delete(this.baseUrl + `deleteCar/${id}`,{headers});
  }

  getCarDetail(id:string){
    return this.http.get<any>(this.baseUrl + `getCarById/${id}`);
  }

  updateCar(id:string, carData:CarModel){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    });
    return this.http.put<any>(this.baseUrl + `updateCar/${id}`, carData, {headers});
  }
  addCar(carData:CarModel){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    });
    return this.http.post<any>(this.baseUrl + "addCar", carData,{headers});
  }
}
