import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostalCodeWeatherComponent } from './postal-code-weather.component';

describe('PostalCodeWeatherComponent', () => {
  let component: PostalCodeWeatherComponent;
  let fixture: ComponentFixture<PostalCodeWeatherComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PostalCodeWeatherComponent]
    });
    fixture = TestBed.createComponent(PostalCodeWeatherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
