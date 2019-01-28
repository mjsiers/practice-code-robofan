import { Component, OnInit, Input } from '@angular/core';
import { RoboFan } from '../robofan';

@Component({
  selector: 'app-fancard',
  templateUrl: './fancard.component.html',
  styleUrls: ['./fancard.component.css']
})
export class FancardComponent implements OnInit {
  @Input() fan: RoboFan;

  constructor() { }

  ngOnInit() {
  }
}
