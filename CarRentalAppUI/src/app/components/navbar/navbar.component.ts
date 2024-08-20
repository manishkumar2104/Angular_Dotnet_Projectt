import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isAuthenticated:boolean= false;
  isUserLogIn:boolean= false;
  isAdminLogIn:boolean= false;
  constructor(private route: Router){}
  ngOnInit(): void {
    this.route.events.subscribe(()=>{
      this.isAuthenticated= localStorage.getItem('isUserLoggedIn')=='true'|| localStorage.getItem('isAdminLoggedin')=='true';
      this.isUserLogIn= localStorage.getItem('isUserLoggedIn')=='true';
      this.isAdminLogIn= localStorage.getItem('isAdminLoggedin')=='true';
    })
  }

  getDashboardLink(): string[] {
    // Check the user's login status and return the appropriate dashboard link
    if (this.isAuthenticated) {
      if(this.isUserLogIn){
        return ['/dashboard'];
      }
      if(this.isAdminLogIn){
        return ['/adminDashboard'];
      } 
    }
    return [''];
  }

  logOutUser(){
    localStorage.removeItem('loggedInUserType');
    localStorage.removeItem('authToken');
    localStorage.removeItem('isAdminLoggedin');
    localStorage.removeItem('isUserLoggedIn');
    this.isAuthenticated= false;
  }

}
