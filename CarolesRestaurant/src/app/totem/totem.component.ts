import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { TotemCodeComponent } from '../totem-code/totem-code.component';

@Component({
  selector: 'app-totem',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './totem.component.html',
  styleUrl: './totem.component.css'
})
export class TotemComponent {
  constructor(public dialog: MatDialog){}

  openDialog() {
    this.dialog.open(TotemCodeComponent);
  }
}
