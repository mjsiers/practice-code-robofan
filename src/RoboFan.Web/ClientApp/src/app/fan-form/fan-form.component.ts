import { Component, OnInit } from '@angular/core';
import { RoboFanDataService } from '../robofan-data.service';
import { RoboFanCreate } from '../robofan-create';

@Component({
  selector: 'app-fan-form',
  templateUrl: './fan-form.component.html',
  styleUrls: ['./fan-form.component.css']
})
export class FanFormComponent implements OnInit {
  fan = new RoboFanCreate();
  constructor(private fanDataService: RoboFanDataService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.fanDataService.postCreate(this.fan);
  }
}
