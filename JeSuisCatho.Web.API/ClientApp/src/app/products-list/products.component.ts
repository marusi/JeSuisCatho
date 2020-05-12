import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from '../services/product.service';
import { FileService } from '../services/file.service';
// import { Router, ActivatedRoute } from '@angular/router';
// import 'rxjs/observable/ForkJoinObservable';
import { SnackbarService } from '../services/snackbar.service';
import { KeyValuePair, Supplier, Product, Info, Sell } from '../models/product';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})

export class ProductsComponent implements OnInit {
  @Input('product') product: Product;
  products: Product;
  productId: number;
 // photos: any[];
  private categoryItems: KeyValuePair[];
  private subCategoryItems: KeyValuePair[];
  private suppliers: Supplier;

  constructor(
    private productService: ProductService,
    private fileService: FileService,
    private snackBarService: SnackbarService)
  {
   
   
  }

  ngOnInit() {
    this.productService.getCategoryItems().subscribe(categoryItems =>
      this.categoryItems = categoryItems);

    this.productService.getSuppliers().subscribe(suppliers =>
      this.suppliers = suppliers);
    this.populateProducts();

   
  }

     


  populateProducts() {
    this.productService.getProducts().subscribe(result => {
      this.products = result;
  

    
    
    }, error => console.log(error));


  

  }
}
