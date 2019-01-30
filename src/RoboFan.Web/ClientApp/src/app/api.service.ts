import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/observable/of';
import { RoboFan } from './robofan';
import { RoboFanCreate } from './robofan-create';
import { RoboFanGenerate } from './robofan-generate';
import { RoboFanDelay } from './robofan-delay';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    console.log('ApiService::BASEURL:', baseUrl);
    this.baseUrl = baseUrl;
  }

  //getFansAll() : Observable<RoboFan[]> {
    //return Observable.of(listfans.robofans);
  //}

  postCreate(fan: RoboFanCreate) {
    var url = this.baseUrl + 'api/robofan/create'
    console.log('ApiService::postCreate', fan);
  }

  postGenerate(generate: RoboFanGenerate) {
    var url = this.baseUrl + 'api/robofan/generate'
    console.log('ApiService::postGenerate', generate);
  }

  postDelay(delay: RoboFanDelay) {
    var url = this.baseUrl + 'api/robofan/delay'
    console.log('ApiService::postDelay', delay);
  }

  private handleError (error: Response | any) {
    console.error('ApiService::handleError', error);
    return Observable.throw(error);
  }

  //public get() {
    // Get all jogging data
    //return this.http.get(this.accessPointUrl, { headers: this.headers });
  //}

  //public add(payload) {
    //return this.http.post(this.accessPointUrl, payload, { headers: this.headers });
  //}

  //public remove(payload) {
    //return this.http.delete(this.accessPointUrl + '/' + payload.id, { headers: this.headers });
  //}

  //public update(payload) {
    //return this.http.put(this.accessPointUrl + '/' + payload.id, payload, { headers: this.headers });
  //}
}
