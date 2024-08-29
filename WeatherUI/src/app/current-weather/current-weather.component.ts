import { Component } from '@angular/core';
import { WeatherService } from '../weather.service';

@Component({
  selector: 'app-current-weather',
  templateUrl: './current-weather.component.html',
  styleUrls: ['./current-weather.component.css']
})
export class CurrentWeatherComponent {
  weatherData: any;
  city: string = '';

  constructor(private weatherService: WeatherService) { }

  getWeather() {
    this.weatherService.getCurrentWeather(this.city).subscribe(data => {
      this.weatherData = data;
    });
  }
}
