import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAllAgreementsComponent } from './view-all-agreements.component';

describe('ViewAllAgreementsComponent', () => {
  let component: ViewAllAgreementsComponent;
  let fixture: ComponentFixture<ViewAllAgreementsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewAllAgreementsComponent]
    });
    fixture = TestBed.createComponent(ViewAllAgreementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
