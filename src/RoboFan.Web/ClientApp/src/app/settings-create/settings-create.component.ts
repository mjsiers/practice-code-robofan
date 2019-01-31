import { Component, OnInit } from '@angular/core';
import { RoboFanDataService } from '../robofan-data.service';
import { RoboFanCreate } from '../robofan-create';

@Component({
  selector: 'app-settings-create',
  templateUrl: './settings-create.component.html',
  styleUrls: ['./settings-create.component.css']
})
export class SettingsCreateComponent implements OnInit {
  fan = new RoboFanCreate();
  constructor(private fanDataService: RoboFanDataService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.fanDataService.postCreate(this.fan);
  }
}
