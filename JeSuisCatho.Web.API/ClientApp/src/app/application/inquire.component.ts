import { Component, OnInit, ViewChild } from '@angular/core';
import { InquiryService } from './../services/inquiry.service';



import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

// import { DatepickerOptions } from './../ng-datepicker/component/ng-datepicker.component';



@Component({
  selector: 'app-inquire-component',
  templateUrl: './inquire.component.html'
})








export class InquireComponent implements OnInit {

  private locations: any[];

  public requestapply = {
    id: 0,

    isAvailable: false,
    locations: [],

    inquiry: {
      childName: '',
      notes: '',
      dateOfBirth: '',
      parentName: '',
      parentEmail: '',
      parentPhone: '',
      dateOfEntry: ''
    }
  };






 

  constructor(private inquiryService: InquiryService) {  }









  ngOnInit(): void {


    this.inquiryService.getLocations().subscribe(locations =>
      this.locations = locations);

    //  console.log("LOCATIONS", this.locations);

 

  }


  onLocationToggle(locationId, $event) {
    if ($event.target.checked)
      this.requestapply.locations.push(locationId);
    else {
      var index = this.requestapply.locations.indexOf(locationId);
      this.requestapply.locations.splice(index, 1);
    }

  }


  submitRequest() {
    this.inquiryService.create(this.requestapply)
      .subscribe(x => console.log(x));
  }








}
