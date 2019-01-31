import { Component, OnInit } from '@angular/core';
import { RoboFanDataService } from '../robofan-data.service';
import { RoboFanGenerate } from '../robofan-generate';
import { UiService } from '../ui.service';

@Component({
  selector: 'app-settings-generate',
  templateUrl: './settings-generate.component.html',
  styleUrls: ['./settings-generate.component.css']
})
export class SettingsGenerateComponent implements OnInit {
  isDisabled = false;
  generate = new RoboFanGenerate();
  constructor(private fanDataService: RoboFanDataService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.isDisabled = true;
    this.fanDataService.postGenerate(this.generate)
      .subscribe(res => {
        this.isDisabled = false;
      },
      err => {
        console.log("Error occured");
        this.isDisabled = false;
      });
  }
}
