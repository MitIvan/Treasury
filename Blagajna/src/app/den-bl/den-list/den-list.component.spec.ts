import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DenListComponent } from './den-list.component';

describe('DenListComponent', () => {
  let component: DenListComponent;
  let fixture: ComponentFixture<DenListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DenListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DenListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
