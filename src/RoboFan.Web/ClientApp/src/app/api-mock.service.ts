import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
  headers = new HttpHeaders({'Content-Type':'application/json; charset=utf-8'});
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
    var url = this.baseUrl + 'api/robofan/create'
    var body = JSON.stringify(fan);
    console.log('ApiMockService::postCreate', url);
    console.log('ApiMockService::postCreate', fan);
    this.http.post(url, body, { headers: this.headers })
      .subscribe(res => {
        console.log(res);
      },
      err => {
        console.log("Error occured");
      });
  }

  postGenerate(generate: RoboFanGenerate) {
    var url = this.baseUrl + 'api/robofan/generate'
    var body = JSON.stringify(generate);
    console.log('ApiMockService::postGenerate', url);
    console.log('ApiMockService::postGenerate', generate);
    this.http.post(url, body, { headers: this.headers })
      .subscribe(res => {
        console.log(res);
      },
      err => {
        console.log("Error occured");
      });
  }

  postDelay(delay: RoboFanDelay) {
    console.log('ApiMockService::postDelay', delay);
  }

  private handleError (error: Response | any) {
    console.error('ApiMockService::handleError', error);
    return Observable.throw(error);
  }
}
