import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DenItemComponent } from './den-item.component';

describe('DenItemComponent', () => {
  let component: DenItemComponent;
  let fixture: ComponentFixture<DenItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DenItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DenItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
