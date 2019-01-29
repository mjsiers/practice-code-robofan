import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingsDelayComponent } from './settings-delay.component';

describe('SettingsDelayComponent', () => {
  let component: SettingsDelayComponent;
  let fixture: ComponentFixture<SettingsDelayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SettingsDelayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SettingsDelayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
