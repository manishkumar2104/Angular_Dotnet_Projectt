import { HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import {  FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { LoginUser } from 'src/app/models/loginModel';
import { AuthService } from 'src/app/shared/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private authService:AuthService, private route: Router){}
  loginData:LoginUser= {email: '', password: ''}
  loginForm= new FormGroup({
    email: new FormControl('', [ Validators.required, Validators.email]),
    password: new FormControl('', [ Validators.required, Validators.minLength(6)])
  })
  loginUser(){
    this.loginData.email= this.loginForm.value.email!.toString();
    this.loginData.password= this.loginForm.value.password!.toString();
    this.authService.login(this.loginData)
    .subscribe({
      next:(res)=>{
        localStorage.setItem('authToken', res.token);
        console.log(res.token);
        this.getUserRole();
        this.loginForm.reset();
      },
      error:(errorResponse)=>{
        console.log(errorResponse);
      }
    })
  }

  getUserRole(){
    this.authService.getUserRole()
    .subscribe({
      next:(res)=>{
        localStorage.setItem('loggedInUserType',res.userRole);
        if(res.userRole=='Admin'){
          localStorage.setItem('isAdminLoggedin', 'true');
          this.route.navigate(['/adminDashboard']);
        }
        if(res.userRole=='User'){
          localStorage.setItem('isUserLoggedIn', 'true');
          this.route.navigate(['/dashboard']);
        }
      },
      error:(err)=>{
        console.error(err);
      }
    })
    
  }
  get email(){
    return this.loginForm.get('email');
  }

  get password(){
    return this.loginForm.get('password');
  }
}
