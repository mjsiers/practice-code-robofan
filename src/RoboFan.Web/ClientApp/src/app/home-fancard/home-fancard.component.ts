import { Component, OnInit, Input } from '@angular/core';
import { RoboFan } from '../robofan';

@Component({
  selector: 'app-home-fancard',
  templateUrl: './home-fancard.component.html',
  styleUrls: ['./home-fancard.component.css']
})
export class HomeFancardComponent implements OnInit {
  @Input() fan: RoboFan;

  constructor() { }

  ngOnInit() {
  }
}
