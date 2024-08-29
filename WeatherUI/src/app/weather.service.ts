import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  private apiUrl = 'http://localhost:5033'; 

  constructor(private http: HttpClient) { }

  getCurrentWeather(city: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/weather/currentWeather?city=${city}`);
  }

  getForecast(city: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/weather/forecast?city=${city}`);
  }

  getAirQuality(city: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/weather/airquality?city=${city}`);
  }

  getCurrentWeatherByZip(pincode: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/weather/currentWeatherByZip?pincode=${pincode}`);
  }
}
