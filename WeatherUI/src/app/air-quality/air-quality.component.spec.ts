import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AirQualityComponent } from './air-quality.component';

describe('AirQualityComponent', () => {
  let component: AirQualityComponent;
  let fixture: ComponentFixture<AirQualityComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AirQualityComponent]
    });
    fixture = TestBed.createComponent(AirQualityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
