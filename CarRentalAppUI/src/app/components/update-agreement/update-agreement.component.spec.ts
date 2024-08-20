import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateAgreementComponent } from './update-agreement.component';

describe('UpdateAgreementComponent', () => {
  let component: UpdateAgreementComponent;
  let fixture: ComponentFixture<UpdateAgreementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateAgreementComponent]
    });
    fixture = TestBed.createComponent(UpdateAgreementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
