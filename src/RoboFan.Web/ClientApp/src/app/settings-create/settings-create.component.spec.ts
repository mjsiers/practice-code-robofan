import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingsCreateComponent } from './settings-create.component';

describe('SettingsCreateComponent', () => {
  let component: SettingsCreateComponent;
  let fixture: ComponentFixture<SettingsCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SettingsCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SettingsCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
