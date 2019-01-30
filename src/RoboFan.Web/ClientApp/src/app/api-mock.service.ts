import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RoboFan } from './robofan';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/observable/of';
import listfans from '../assets/robofans.json';
import { RoboFanCreate } from './robofan-create';
import { RoboFanGenerate } from './robofan-generate';
import { RoboFanDelay } from './robofan-delay';

@Injectable({
  providedIn: 'root'
})
export class ApiMockService {
  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    console.log('ApiMockService::BASEURL:', baseUrl);
    this.baseUrl = baseUrl;
  }

  getFansAll() : Observable<RoboFan[]> {
    return Observable.of(listfans.robofans);
  }

  postCreate(fan: RoboFanCreate) {
    console.log('ApiMockService::postCreate', fan);
  }

  postGenerate(generate: RoboFanGenerate) {
    console.log('ApiMockService::postGenerate', generate);
  }

  postDelay(delay: RoboFanDelay) {
    console.log('ApiMockService::postDelay', delay);
  }

  private handleError (error: Response | any) {
    console.error('ApiMockService::handleError', error);
    return Observable.throw(error);
  }
}
