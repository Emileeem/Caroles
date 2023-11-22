import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndexUserComponent } from './index-user.component';

describe('IndexUserComponent', () => {
  let component: IndexUserComponent;
  let fixture: ComponentFixture<IndexUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IndexUserComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(IndexUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
