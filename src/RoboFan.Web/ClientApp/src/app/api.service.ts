import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { tap } from 'rxjs/operators';
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
  headers = new HttpHeaders({'Content-Type':'application/json; charset=utf-8'});
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    console.log('ApiService::BASEURL:', baseUrl);
    this.baseUrl = baseUrl;
  }

  private refreshneeded = new Subject<RoboFan[]>();
  getRefreshNeeded() {
    return this.refreshneeded;
  }

  getFansAll(filter: string) : Observable<RoboFan[]> {
    var url = this.baseUrl + 'api/robofan/search'
    if (filter){
      url = url + "?namefilter=" + filter;
    }
    return this.http.get<RoboFan[]>(url);
  }

  postCreate(fan: RoboFanCreate) {
    var url = this.baseUrl + 'api/robofan/create'
    var body = JSON.stringify(fan);
    return this.http.post(url, body, { headers: this.headers })
      .pipe(tap(() => {
          //this.getRefreshNeeded().next();
        })
      );
  }

  postGenerate(generate: RoboFanGenerate) {
    var url = this.baseUrl + 'api/robofan/generate'
    var body = JSON.stringify(generate);
    return this.http.post(url, body, { headers: this.headers })
            .pipe(
              tap(() => {
                //this.getRefreshNeeded().next();
              })
            );
  }

  postDelay(delay: RoboFanDelay) {
    var url = this.baseUrl + 'api/robofan/delay'
    var body = JSON.stringify(delay);
    this.http.post(url, body, { headers: this.headers })
      .subscribe(res => {
        console.log(res);
      },
      err => {
        console.log("Error occured");
      });
  }
}
