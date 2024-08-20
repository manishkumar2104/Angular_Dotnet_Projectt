import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AgreementModel } from '../models/agreement';
import { validateRequestModel } from '../models/validateReturnRequestModel';
import { updateAgreementModel } from '../models/updateAgreement';

@Injectable({
  providedIn: 'root'
})
export class RentService {
  private baseUrl:string = "https://localhost:7198/api/Agreement/"
  constructor(private http:HttpClient) { }

  addAgreement(agreement:AgreementModel){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    });
    return this.http.post<any>(this.baseUrl + 'rentCar', agreement, {headers});
  }
  
  getUserAgreement(){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    });
    return this.http.get<any>(this.baseUrl + 'GetAllUserAgreement', {headers});
  }

  getAgreementById(id:string){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    });
    return this.http.get<any>(this.baseUrl + `getAgreementById/${id}`, {headers});
  }

  requestReturn(id: string){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    });
    return this.http.post<any>(this.baseUrl + `requestReturn/${id}`, null , {headers});
  }

  getAllAgreements(){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    });
    return this.http.get<any>(this.baseUrl + 'getAllAgreement', {headers});
  }
  deleteAgreement(id:string){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    });
    return this.http.delete<any>(this.baseUrl + `deleteAgreement/${id}`, {headers});
  }

  getAllReturnRequestAgreements(){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    });
    return this.http.get(this.baseUrl + 'getAllPendingReturnRequest', {headers});
  }

  validateReturnRequest(validateRequestData: validateRequestModel){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    });
    return this.http.post<any>(this.baseUrl + 'validateReturnRequest', validateRequestData, {headers});
  }

  updateAgreement(agreement:updateAgreementModel){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    });
    return this.http.put<any>(this.baseUrl + 'updateAgreement', agreement, {headers});
  }
}
