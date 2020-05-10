import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  constructor(public snackBar: MatSnackBar) { }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'X', {
      duration: 2000,
      panelClass: 'snackbarwrap',
      verticalPosition: 'top',
      horizontalPosition: 'center'
    });
  }
}