import { Component } from '@angular/core';
import { WeatherService } from '../weather.service';

@Component({
  selector: 'app-air-quality',
  templateUrl: './air-quality.component.html',
  styleUrls: ['./air-quality.component.css']
})
export class AirQualityComponent {
  city: string = '';
  airQuality: any;

  constructor(private weatherService: WeatherService) { }

  
  getAirQuality() {
    if (this.city) {
      this.weatherService.getAirQuality(this.city).subscribe(
        data => {
          this.airQuality = data;
        },
        error => {
          console.error('Error fetching air quality data:', error);
        }
      );
    }
  }
}
