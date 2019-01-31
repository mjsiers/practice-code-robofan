import { Component, OnInit } from '@angular/core';
import { RoboFanDataService } from '../robofan-data.service';
import { RoboFan } from '../robofan';
import { UiService } from '../ui.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  fans: RoboFan[];
  filter: string;
  constructor(private fanDataService: RoboFanDataService, private ui: UiService) { }

  ngOnInit() {
    // subscripe to the refresh needed stream
    // this gets fired when new fans are created or filter chnaged
    this.fanDataService.getRefreshNeeded()
      .subscribe(() => {
        // refetch the fans
        this.fetchFans(this.filter);
      });

    // initialize by fetching once at init time
    this.fetchFans(this.filter, false);
  }

  private fetchFans(filter: string, spin:boolean = true) {
    if (spin) {
      this.ui.spin$.next(true);
    }

    this.fanDataService
      .getFansAll(filter)
      .subscribe((fans) => {
        this.fans = fans;
        if (spin) {
          this.ui.spin$.next(false);
        }
      });
  }

  onKeyEnter() {
     // trigger the signal to reload the data using the filter
    //this.fanDataService.getRefreshNeeded().next();
    this.fetchFans(this.filter);
  }

  search() {
    // trigger the signal to reload the data using the filter
    //this.fanDataService.getRefreshNeeded().next();
    this.fetchFans(this.filter);
  }
}
