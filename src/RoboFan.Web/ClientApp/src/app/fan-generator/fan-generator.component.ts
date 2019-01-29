import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-fan-generator',
  templateUrl: './fan-generator.component.html',
  styleUrls: ['./fan-generator.component.css']
})
export class FanGeneratorComponent implements OnInit {
  numfans = 1;
  constructor() { }

  ngOnInit() {
  }

  onSubmit() {
    alert("Thanks for submitting! Data: " + JSON.stringify(this.numfans));
  }
}
