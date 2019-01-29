import { Component, OnInit } from '@angular/core';
import { DelayEdit } from '../delay-edit';

@Component({
  selector: 'app-settings-delay',
  templateUrl: './settings-delay.component.html',
  styleUrls: ['./settings-delay.component.css']
})
export class SettingsDelayComponent implements OnInit {
  delay = new DelayEdit();
  constructor() { }

  ngOnInit() {
  }

  onSubmit() {
    alert("Thanks for submitting! Data: " + JSON.stringify(this.delay));
  }
}
