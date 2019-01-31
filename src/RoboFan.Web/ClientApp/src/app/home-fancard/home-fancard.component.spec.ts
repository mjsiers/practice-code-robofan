import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeFancardComponent } from './home-fancard.component';

describe('HomeFancardComponent', () => {
  let component: HomeFancardComponent;
  let fixture: ComponentFixture<HomeFancardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeFancardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeFancardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
