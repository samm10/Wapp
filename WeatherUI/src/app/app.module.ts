import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// Import Angular Material modules
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { CurrentWeatherComponent } from './current-weather/current-weather.component';
import { ForecastComponent } from './forecast/forecast.component';
import { AirQualityComponent } from './air-quality/air-quality.component';
import { PostalCodeWeatherComponent } from './postal-code-weather/postal-code-weather.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    CurrentWeatherComponent,
    ForecastComponent,
    AirQualityComponent,
    PostalCodeWeatherComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    MatCardModule,
    FormsModule,
    MatToolbarModule,  // Import MatToolbarModule
    MatButtonModule,   // Import MatButtonModule
    MatFormFieldModule, // Import MatFormFieldModule
    MatInputModule    // Import MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
