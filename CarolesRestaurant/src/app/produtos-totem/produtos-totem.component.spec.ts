import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdutosTotemComponent } from './ProdutosTotemComponent';

describe('ProdutosTotemComponent', () => {
  let component: ProdutosTotemComponent;
  let fixture: ComponentFixture<ProdutosTotemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProdutosTotemComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProdutosTotemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
