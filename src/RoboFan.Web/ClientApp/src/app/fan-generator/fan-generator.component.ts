import { Component, OnInit } from '@angular/core';
import { RoboFanDataService } from '../robofan-data.service';
import { RoboFanGenerate } from '../robofan-generate';

@Component({
  selector: 'app-fan-generator',
  templateUrl: './fan-generator.component.html',
  styleUrls: ['./fan-generator.component.css']
})
export class FanGeneratorComponent implements OnInit {
  generate = new RoboFanGenerate();
  constructor(private fanDataService: RoboFanDataService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.fanDataService.postGenerate(this.generate);
  }
}
