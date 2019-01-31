import { Component, OnInit } from '@angular/core';
import { RoboFanDataService } from '../robofan-data.service';
import { RoboFanGenerate } from '../robofan-generate';

@Component({
  selector: 'app-settings-generate',
  templateUrl: './settings-generate.component.html',
  styleUrls: ['./settings-generate.component.css']
})
export class SettingsGenerateComponent implements OnInit {
  generate = new RoboFanGenerate();
  constructor(private fanDataService: RoboFanDataService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.fanDataService.postGenerate(this.generate);
  }
}
