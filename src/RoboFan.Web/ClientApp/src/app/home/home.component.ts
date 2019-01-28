import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { PageEvent, MatPaginator } from '@angular/material';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';
import 'rxjs/add/observable/merge';
import { RoboFanDataService } from '../robofan-data.service';
import { RoboFan } from '../robofan';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  //length = 0;
  //pageIndex = 0;
  //pageSize = 5;
  //robofans: any;
  //database: Database;
  //pageEvent: PageEvent;
  //dataSource : MyDataSource;
  //@ViewChild(MatPaginator) paginator: MatPaginator;

  fans: RoboFan[];

  constructor(private fanDataService: RoboFanDataService) { }

  ngOnInit() {
    this.fanDataService
      .getFansAll()
      .subscribe(
        (fans) => {
          this.fans = fans;
        }
      );

    ////this.fanDataService.getFansAll().subscribe(data =>  {
    ////  console.log(data);
      //this.robofans= data.robofans;
      //this.length = this.robofans.length;
    ////  this.database = new Database(data);
    ////  this.dataSource = new MyDataSource(this.database, this.paginator);
    ////});
  }
}

export class Database { // {{{
  /** Stream that emits whenever the data has been modified.*/
  dataChange: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);
  get data(): any[] {
    return this.dataChange.value;
  }

  constructor(data) {
    // Fill up the database .
    this.dataChange.next(data);
  }

  getChange(data){
    this.dataChange.next(data);
  }
}

export class MyDataSource extends DataSource<any> {
  /** Stream of data that is provided to the table. */
  constructor(private dataBase: Database, private paginator: MatPaginator) {
    super();
  }

  /** Connect function called by the table to retrieve one stream containing the data to render. */
  connect(): Observable<any[]> {
    //To handle data change event or paginator page change event
    const displayDataChanges = [
      this.dataBase.dataChange,
      this.paginator.page
    ];

    return Observable.merge(displayDataChanges).pipe(map(() => {
      let data;
      this.dataBase.dataChange.subscribe(xdata=>{
        data=Object.values(xdata);
      });

      // // Grab the page's slice of data.
      const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
      const finalData = data.splice(startIndex, this.paginator.pageSize);
      return finalData;
    }));
  }

  disconnect() {}
}
