import { Component } from '@angular/core';
import { WeatherService } from '../weather.service';

@Component({
  selector: 'app-postal-code-weather',
  templateUrl: './postal-code-weather.component.html',
  styleUrls: ['./postal-code-weather.component.css']
})
export class PostalCodeWeatherComponent {
  pincode: string = '';
  weather: any;

  constructor(private weatherService: WeatherService) { }

  
  getWeatherByPostalCode() {
    if (this.pincode) {
      this.weatherService.getCurrentWeatherByZip(this.pincode).subscribe(
        data => {
          this.weather = data;
        },
        error => {
          console.error('Error fetching weather data by postal code:', error);
        }
      );
    }
  }
}
