import { Component, OnInit } from '@angular/core';
import { RoboFanEdit } from '../robofan-edit';

@Component({
  selector: 'app-fan-form',
  templateUrl: './fan-form.component.html',
  styleUrls: ['./fan-form.component.css']
})
export class FanFormComponent implements OnInit {
  fan = new RoboFanEdit();
  constructor() { }

  ngOnInit() {
  }

  onSubmit() {
    alert("Thanks for submitting! Data: " + JSON.stringify(this.fan));
  }
}
