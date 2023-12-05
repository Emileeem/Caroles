import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogTitle,
  MatDialogContent,
} from '@angular/material/dialog';
import { CodeComponent} from '../code/code.component';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductServiceService } from '../services/product-service.service';
import { ProductDataIngredients } from '../data/product-dataIngredients';

@Component({
  selector: 'app-ingredients',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './ingredients.component.html',
  styleUrl: './ingredients.component.css'
})
export class IngredientsComponent implements OnInit, OnDestroy {

  subscription: any;
  constructor(public dialog: MatDialog,
      private service: ProductServiceService,
      private route: ActivatedRoute){}
  ngOnDestroy(): void {
    throw new Error('Method not implemented.');
  }

  produtos: ProductDataIngredients[] = [];

  ngOnInit(): void {

  this.subscription = this.route.params
    .subscribe(params => {
      var productId = params['id']
      this.service.getSolo().subscribe(
        (produto : any) => {
          this.produtos = []
          produto.a.forEach((x:any) => this.produtos.push(x))
          console.log(this.produtos)
        },
      )
    })
  }

    openDialog() {
      this.dialog.open(CodeComponent);
    }
}
