import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintKasaComponent } from './print-kasa.component';

describe('PrintKasaComponent', () => {
  let component: PrintKasaComponent;
  let fixture: ComponentFixture<PrintKasaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintKasaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintKasaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
