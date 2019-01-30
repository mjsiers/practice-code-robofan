import { Component, OnInit } from '@angular/core';
import { RoboFanDataService } from '../robofan-data.service';
import { RoboFanDelay } from '../robofan-delay';

@Component({
  selector: 'app-settings-delay',
  templateUrl: './settings-delay.component.html',
  styleUrls: ['./settings-delay.component.css']
})
export class SettingsDelayComponent implements OnInit {
  delay = new RoboFanDelay();
  constructor(private fanDataService: RoboFanDataService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.fanDataService.postDelay(this.delay);
  }
}
