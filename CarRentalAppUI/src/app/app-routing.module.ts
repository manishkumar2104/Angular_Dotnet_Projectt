import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { userAuthGuard } from './user-auth.guard';
import { adminAuthGuard } from './admin-auth.guard';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { UpdateCarComponent } from './components/update-car/update-car.component';
import { AddCarComponent } from './components/add-car/add-car.component';
import { RentCarPageComponent } from './components/rent-car-page/rent-car-page.component';
import { CreateAgreementComponent } from './components/create-agreement/create-agreement.component';
import { UserAgreementsComponent } from './components/user-agreements/user-agreements.component';
import { ViewAgreementComponent } from './components/view-agreement/view-agreement.component';
import { ViewAllAgreementsComponent } from './components/view-all-agreements/view-all-agreements.component';
import { ViewReturnRequestComponent } from './components/view-return-request/view-return-request.component';
import { UpdateAgreementComponent } from './components/update-agreement/update-agreement.component';
import { ViewCarComponent } from './components/view-car/view-car.component';

const routes: Routes = [
  {path : '', component: HomeComponent},
  {path: 'viewCar/:carId', component: ViewCarComponent},
  {path : 'login', component: LoginComponent},
  {path : 'dashboard', component: UserDashboardComponent, canActivate:[userAuthGuard]},
  {path : 'adminDashboard', component: AdminDashboardComponent, canActivate:[adminAuthGuard]},
  {path : 'updateCar/:carId', component: UpdateCarComponent, canActivate:[adminAuthGuard]},
  {path : 'addCar', component: AddCarComponent, canActivate:[adminAuthGuard]},
  {path : 'rentCarPage/:carId', component:RentCarPageComponent, canActivate:[userAuthGuard]},
  {path : 'agreement/:carId/:duration', component: CreateAgreementComponent, canActivate:[userAuthGuard]},
  {path : 'userAgreements', component: UserAgreementsComponent, canActivate:[userAuthGuard]},
  {path : 'viewAgreement/:agreementId', component: ViewAgreementComponent, canActivate:[userAuthGuard]},
  {path : 'viewAllAgreement', component: ViewAllAgreementsComponent, canActivate:[adminAuthGuard]},
  {path : 'viewReturnRequest', component: ViewReturnRequestComponent, canActivate:[adminAuthGuard]},
  {path : 'updateAgreement/:agreementId', component: UpdateAgreementComponent, canActivate:[adminAuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
