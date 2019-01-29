import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RoboFan } from './robofan';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/observable/of';
import listfans from '../assets/robofans.json';

@Injectable({
  providedIn: 'root'
})
export class ApiMockService {

  constructor(private http: HttpClient) { }

  getFansAll() : Observable<RoboFan[]> {
    return Observable.of(listfans.robofans);
  }

  private handleError (error: Response | any) {
    console.error('ApiMockService::handleError', error);
    return Observable.throw(error);
  }
}
