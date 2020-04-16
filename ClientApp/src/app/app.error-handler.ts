//import * as Raven from 'raven-js'; 
// import { ToastyService } from 'ng2-toasty';
import { ErrorHandler, Inject, NgZone, isDevMode } from '@angular/core';

export class AppErrorHandler implements ErrorHandler {
  constructor(
    private ngZone: NgZone,
   // @Inject(ToastyService) private toastyService: ToastyService
  )
    {
  }

  handleError(error: any): void {
  /*  if (!isDevMode())
      Raven.captureException(error.originalError || error)
    else
      throw error;
      */
   // console.log("Edgar this is an ERROR");
    this.ngZone.run(() => {
   /*   this.toastyService.error({
        title: 'Error Things',
        msg: 'We Didnt Expect this! However, an unexpected error happened:-(',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      }); */
    });

    
  }
}
