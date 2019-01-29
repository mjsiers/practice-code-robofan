import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppMaterialModule } from './app-material/app-material.module';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { ApiService } from './api.service';
import { ApiMockService } from './api-mock.service';
import { RoboFanDataService } from './robofan-data.service';
import { HomeComponent } from './home/home.component';
import { SettingsComponent } from './settings/settings.component';
import { FancardComponent } from './fancard/fancard.component';
import { FanGeneratorComponent } from './fan-generator/fan-generator.component';
import { FanFormComponent } from './fan-form/fan-form.component';
import { SettingsDelayComponent } from './settings-delay/settings-delay.component';


const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full' },
  {path: 'settings', component: SettingsComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SettingsComponent,
    FancardComponent,
    FanGeneratorComponent,
    FanFormComponent,
    SettingsDelayComponent
  ],
  imports: [
    //BrowserModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    FlexLayoutModule,
    AppMaterialModule,
    RouterModule.forRoot(routes)
  ],
  providers: [ApiService, ApiMockService, RoboFanDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
