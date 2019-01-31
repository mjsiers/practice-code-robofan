import { Component, OnInit } from '@angular/core';
import { RoboFanDataService } from '../robofan-data.service';
import { RoboFanCreate } from '../robofan-create';

@Component({
  selector: 'app-settings-create',
  templateUrl: './settings-create.component.html',
  styleUrls: ['./settings-create.component.css']
})
export class SettingsCreateComponent implements OnInit {
  isDisabled = false;
  fan = new RoboFanCreate();
  constructor(private fanDataService: RoboFanDataService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.isDisabled = true;
    this.fanDataService.postCreate(this.fan)
      .subscribe(res => {
        this.isDisabled = false;
      },
      err => {
        console.log("Error occured");
        this.isDisabled = false;
      });
  }
}
