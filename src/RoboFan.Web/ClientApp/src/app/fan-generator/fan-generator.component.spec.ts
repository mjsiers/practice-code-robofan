import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FanGeneratorComponent } from './fan-generator.component';

describe('FanGeneratorComponent', () => {
  let component: FanGeneratorComponent;
  let fixture: ComponentFixture<FanGeneratorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FanGeneratorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FanGeneratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
