import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TotemCodeComponent } from './totem-code.component';

describe('TotemCodeComponent', () => {
  let component: TotemCodeComponent;
  let fixture: ComponentFixture<TotemCodeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TotemCodeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TotemCodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
