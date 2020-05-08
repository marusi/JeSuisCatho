import { ToastrService } from 'ngx-toastr';
import { ProductService } from '../services/product.service';
import { Component, OnInit, ElementRef, ViewChild, NgZone} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FileService } from '../services/file.service';
import { CartService } from '../services/cart.service';
// import { ProgressService, BrowserXhrWithProgress } from '../services/progress.service';
// import { XhrFactory, HttpEventType } from '@angular/common/http';



@Component({
  templateUrl: 'view-product.html',
  styleUrls: ['view-product.css']
})
export class ViewProductComponent implements OnInit {
 
  product: any;
  productId: number;
  photos: any[];

  constructor(
    
 
    private router: Router,
   
    private route: ActivatedRoute, 
    private toastrService: ToastrService,
    private productService: ProductService,
    private cartService: CartService,
    private fileService: FileService) { 

    route.params.subscribe(p => {
      this.productId = +p['id'];
      if (isNaN(this.productId) || this.productId <= 0) {
        router.navigate(['/products']);
        return;
      }
    });
  }

  ngOnInit() {

    this.fileService.getPhotos(this.productId)
      .subscribe(
        photos => this.photos = photos);


    this.productService.getProduct(this.productId)
      .subscribe(
       p => this.product = p,
        err => {
          if (err.status == 404) {
            this.router.navigate(['/products']);
            return; 
          }
        });

    this.cartService.getOldCart();
   
  }

 /* delete() {
    if (confirm("Are you sure?")) {
      this.productService.futaEvent(this.product.id)
        .subscribe(x => {
         // this.router.navigate(['/posters']);
        });

    }
  }  */


 
}
