import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingsGenerateComponent } from './settings-generate.component';

describe('SettingsGenerateComponent', () => {
  let component: SettingsGenerateComponent;
  let fixture: ComponentFixture<SettingsGenerateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SettingsGenerateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SettingsGenerateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
