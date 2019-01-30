import { Injectable } from '@angular/core';
import { RoboFan } from './robofan';
import { ApiService } from './api.service';
import { ApiMockService } from './api-mock.service';
import { Observable } from 'rxjs/Observable';
import { RoboFanCreate } from './robofan-create';
import { RoboFanGenerate } from './robofan-generate';
import { RoboFanDelay } from './robofan-delay';

@Injectable({
  providedIn: 'root'
})
export class RoboFanDataService {
  constructor(private api: ApiMockService) { }

  getFansAll() : Observable<RoboFan[]> {
    return this.api.getFansAll();
  }

  postCreate(fan: RoboFanCreate) {
    return this.api.postCreate(fan);
  }

  postGenerate(generate: RoboFanGenerate) {
    return this.api.postGenerate(generate);
  }

  postDelay(delay: RoboFanDelay) {
    return this.api.postDelay(delay);
  }
}
