import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogTitle,
  MatDialogContent,
} from '@angular/material/dialog';
import { CodeComponent} from '../code/code.component';
import { Router } from '@angular/router';
import { ProductServiceService } from '../services/product-service.service';
import { ProductData } from '../data/product-data';

@Component({
  selector: 'app-ingredients',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './ingredients.component.html',
  styleUrl: './ingredients.component.css'
})
export class IngredientsComponent implements OnInit{
    constructor(public dialog: MatDialog,
      private service: ProductServiceService,
      private route: Router ){}

  produtos: ProductData[] = [];

  ngOnInit(): void {
    const productId = window.location.href.split("/")[2];
    this.service.take().subscribe(
      (produto : any) => {
        this.produtos = []
        produto.a.forEach((x:any) => this.produtos.push(x))
        console.log(this.produtos)
      },
  )}


    openDialog() {
      this.dialog.open(CodeComponent);
    }
}
