import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DenBlComponent } from './den-bl.component';

describe('DenBlComponent', () => {
  let component: DenBlComponent;
  let fixture: ComponentFixture<DenBlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DenBlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DenBlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
