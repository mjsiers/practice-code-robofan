import { Injectable } from '@angular/core';
import { RoboFan } from './robofan';
import { ApiService } from './api.service';
import { ApiMockService } from './api-mock.service';
import { Observable } from 'rxjs/Observable';

@Injectable({
  providedIn: 'root'
})
export class RoboFanDataService {

  constructor(private api: ApiMockService) { }

  getFansAll() : Observable<RoboFan[]> {
    return this.api.getFansAll();
  }
}
