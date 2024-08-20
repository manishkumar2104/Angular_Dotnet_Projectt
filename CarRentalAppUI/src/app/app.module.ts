import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { AddCarComponent } from './components/add-car/add-car.component';
import { UpdateCarComponent } from './components/update-car/update-car.component';
import { RentCarPageComponent } from './components/rent-car-page/rent-car-page.component';
import { CreateAgreementComponent } from './components/create-agreement/create-agreement.component';
import { UserAgreementsComponent } from './components/user-agreements/user-agreements.component';
import { ViewAgreementComponent } from './components/view-agreement/view-agreement.component';
import { ViewAllAgreementsComponent } from './components/view-all-agreements/view-all-agreements.component';
import { ViewReturnRequestComponent } from './components/view-return-request/view-return-request.component';
import { UpdateAgreementComponent } from './components/update-agreement/update-agreement.component';
import { ViewCarComponent } from './components/view-car/view-car.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    NavbarComponent,
    UserDashboardComponent,
    AdminDashboardComponent,
    AddCarComponent,
    UpdateCarComponent,
    RentCarPageComponent,
    CreateAgreementComponent,
    UserAgreementsComponent,
    ViewAgreementComponent,
    ViewAllAgreementsComponent,
    ViewReturnRequestComponent,
    UpdateAgreementComponent,
    ViewCarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
