import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductService } from './../services/product.service';
import { CartService } from './../services/cart.service';

import { ActivatedRoute, Router } from '@angular/router';
import { SnackbarService } from '../services/snackbar.service';


import { SaveProduct } from '../models/product';


@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})

export class ProductFormComponent implements OnInit {

  private categoryItems: any[];
  private subCategoryItems: any[];

  private suppliers: any[];
  private product: any = {
    id: 0,
    categoryItemId: 0,
    subCategoryItemId: 0,
    suppliers: [],
    info: {},
    sell: {}
  };

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBarService: SnackbarService
  ) {
    route.params.subscribe(p => {
      this.product.id = +p['id'] || 0;
    });

  }
    
  ngOnInit(): void {

    this.productService.getCategoryItems().subscribe(categoryItems =>
      this.categoryItems = categoryItems);

   



    this.productService.getSuppliers().subscribe(suppliers =>
      this.suppliers = suppliers);

  
    this.cartService.getOldCart();



  }






  onCategoryItemChange() {

    const selectedCategoryItem = this.categoryItems.find(c => c.id == this.product.categoryItemId);

    this.subCategoryItems = selectedCategoryItem ? selectedCategoryItem.subCategoryItems : [];

  }

  onSupplierToggle(supplierId, $event) {
    if ($event.target.checked)
      this.product.suppliers.push(supplierId);
    else {
      const index = this.product.suppliers.indexOf(supplierId);
      this.product.suppliers.splice(index, 1);
    }

  }

  submitProduct() {
    this.productService.create(this.product)
      .subscribe(x => {
  
        this.snackBarService.showSnackBar('Product created successfuly');
      });
  }




}
