import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeducionesComponent } from './deduciones.component';

describe('DeducionesComponent', () => {
  let component: DeducionesComponent;
  let fixture: ComponentFixture<DeducionesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeducionesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeducionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
