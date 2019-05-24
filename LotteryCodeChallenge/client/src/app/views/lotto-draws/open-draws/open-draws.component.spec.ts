import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenDrawsComponent } from './open-draws.component';

describe('OpenDrawsComponent', () => {
  let component: OpenDrawsComponent;
  let fixture: ComponentFixture<OpenDrawsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpenDrawsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpenDrawsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
