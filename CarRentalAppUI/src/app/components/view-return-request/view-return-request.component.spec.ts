import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewReturnRequestComponent } from './view-return-request.component';

describe('ViewReturnRequestComponent', () => {
  let component: ViewReturnRequestComponent;
  let fixture: ComponentFixture<ViewReturnRequestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewReturnRequestComponent]
    });
    fixture = TestBed.createComponent(ViewReturnRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
