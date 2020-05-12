import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { Order } from '../models/order';
import { ProductOrdersService } from '../services/product.order.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-user-orders',
  templateUrl: './user-orders.component.html',
  styleUrls: ['./user-orders.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed, void', style({ height: '0px', minHeight: '0', display: 'none' })),
      state('expanded', style({ height: '*' })),
      transition('* <=> *', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ]
})
export class ProductOrdersComponent implements OnInit, OnDestroy {

  displayedColumns: string[] = ['orderId', 'orderedOn', 'orderTotal'];
  dataSource = new MatTableDataSource<Order>();
  expandedElement: null;
  private paginator: MatPaginator;
  @ViewChild(MatPaginator, { static: false }) set matPaginator(mp: MatPaginator) {

    /*
    * Since we are using *ngIf with mat-table.
    * Refer - https://github.com/angular/components/issues/15008#issuecomment-516386055
    */
    this.dataSource.paginator = mp;
  }
  userId;
  isLoading = true;
  private unsubscribe$ = new Subject<void>();

  constructor(private orderService: ProductOrdersService) {
    this.userId = localStorage.getItem('id');
  }

  ngOnInit() {
    this.getMyOrderDetails();
  }

  getMyOrderDetails() {
    this.orderService.myOrderDetails(this.userId)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((result: Order[]) => {
        if (result !== null) {
          this.dataSource.data = Object.values(result);
        }
      }, error => {
        console.log('Error ocurred while fetching my order details : ', error);
      });
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
