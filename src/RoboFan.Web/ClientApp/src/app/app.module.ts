import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppMaterialModule } from './app-material/app-material.module';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RouterModule, Routes } from '@angular/router';
import { OverlayModule } from '@angular/cdk/overlay'
import { MatSpinner } from '@angular/material';

import { AppComponent } from './app.component';
import { ApiService } from './api.service';
import { ApiMockService } from './api-mock.service';
import { RoboFanDataService } from './robofan-data.service';
import { HomeComponent } from './home/home.component';
import { HomeFancardComponent } from './home-fancard/home-fancard.component';
import { SettingsComponent } from './settings/settings.component';
import { SettingsDelayComponent } from './settings-delay/settings-delay.component';
import { SettingsCreateComponent } from './settings-create/settings-create.component';
import { SettingsGenerateComponent } from './settings-generate/settings-generate.component';


const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full' },
  {path: 'settings', component: SettingsComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HomeFancardComponent,
    SettingsComponent,
    SettingsDelayComponent,
    SettingsCreateComponent,
    SettingsGenerateComponent
  ],
  imports: [
    //BrowserModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    FlexLayoutModule,
    OverlayModule,
    AppMaterialModule,
    RouterModule.forRoot(routes)
  ],
  providers: [ApiService, ApiMockService, RoboFanDataService],
  bootstrap: [AppComponent],
  entryComponents: [ MatSpinner ]
})
export class AppModule { }
