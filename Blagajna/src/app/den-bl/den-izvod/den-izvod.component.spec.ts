import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DenIzvodComponent } from './den-izvod.component';

describe('DenIzvodComponent', () => {
  let component: DenIzvodComponent;
  let fixture: ComponentFixture<DenIzvodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DenIzvodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DenIzvodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
