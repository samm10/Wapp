import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CurrentWeatherComponent } from './current-weather/current-weather.component';
import { ForecastComponent } from './forecast/forecast.component';
import { AirQualityComponent } from './air-quality/air-quality.component';
import { PostalCodeWeatherComponent } from './postal-code-weather/postal-code-weather.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'current-weather', component: CurrentWeatherComponent },
  { path: 'forecast', component: ForecastComponent },
  { path: 'air-quality', component: AirQualityComponent },
  { path: 'postal-code-weather', component: PostalCodeWeatherComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
