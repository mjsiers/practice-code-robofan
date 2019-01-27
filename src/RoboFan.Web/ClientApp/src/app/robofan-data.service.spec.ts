import { TestBed } from '@angular/core/testing';

import { RobofanDataService } from './robofan-data.service';

describe('RobofanDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RobofanDataService = TestBed.get(RobofanDataService);
    expect(service).toBeTruthy();
  });
});
