import { Component } from '@angular/core';
import { WeatherService } from '../weather.service';

@Component({
  selector: 'app-forecast',
  templateUrl: './forecast.component.html',
  styleUrls: ['./forecast.component.css']
})
export class ForecastComponent {
  city: string = '';
  forecast: any;

  constructor(private weatherService: WeatherService) { }

  
  getForecast() {
    if (this.city) {
      this.weatherService.getForecast(this.city).subscribe(
        data => {
          // Slice the last 5 records
          this.forecast = {
            ...data,
            list: data.list.slice(-5)
          };
        },
        error => {
          console.error('Error fetching forecast data:', error);
        }
      );
    }
  }
}
