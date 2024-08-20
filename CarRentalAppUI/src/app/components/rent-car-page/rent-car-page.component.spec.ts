import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RentCarPageComponent } from './rent-car-page.component';

describe('RentCarPageComponent', () => {
  let component: RentCarPageComponent;
  let fixture: ComponentFixture<RentCarPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RentCarPageComponent]
    });
    fixture = TestBed.createComponent(RentCarPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
