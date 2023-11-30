import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProdutoComponent } from '../produto/produto.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-index-admin',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './index-admin.component.html',
  styleUrl: './index-admin.component.css'
})
export class IndexAdminComponent {
  constructor(public dialog: MatDialog){}

    openDialog() {
      this.dialog.open(ProdutoComponent);
    }
}
