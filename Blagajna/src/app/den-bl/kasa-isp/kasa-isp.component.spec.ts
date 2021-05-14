import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KasaIspComponent } from './kasa-isp.component';

describe('KasaIspComponent', () => {
  let component: KasaIspComponent;
  let fixture: ComponentFixture<KasaIspComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KasaIspComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KasaIspComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
