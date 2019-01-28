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


const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full' },
  {path: 'settings', component: SettingsComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SettingsComponent,
    FancardComponent
  ],
  imports: [
    //BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserModule,
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
