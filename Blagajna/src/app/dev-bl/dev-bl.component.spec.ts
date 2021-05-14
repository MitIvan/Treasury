import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DevBlComponent } from './dev-bl.component';

describe('DevBlComponent', () => {
  let component: DevBlComponent;
  let fixture: ComponentFixture<DevBlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DevBlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DevBlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
