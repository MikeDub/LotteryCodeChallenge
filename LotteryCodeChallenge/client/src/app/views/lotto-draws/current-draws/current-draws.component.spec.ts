import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentDrawsComponent } from './current-draws.component';

describe('CurrentDrawsComponent', () => {
  let component: CurrentDrawsComponent;
  let fixture: ComponentFixture<CurrentDrawsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrentDrawsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentDrawsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
