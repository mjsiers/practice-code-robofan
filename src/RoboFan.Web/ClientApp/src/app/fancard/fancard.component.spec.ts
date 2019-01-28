import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FancardComponent } from './fancard.component';

describe('FancardComponent', () => {
  let component: FancardComponent;
  let fixture: ComponentFixture<FancardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FancardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FancardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
