
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import {ChurchService} from '../services/church.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable, forkJoin } from 'rxjs';
 import { SaveChurch, Church } from '../models/church';
// import 'rxjs/observable/ForkJoinObservable';
import { SnackbarService } from '../services/snackbar.service';




@Component({
  selector: 'app-church-form',
  templateUrl: './church-form.component.html',
  styleUrls: ['./church-form.component.css']
})

export class ChurchFormComponent implements OnInit {
  public archDioceses: any[];
  public dioceses = [];
  public deaneries = [];
  public counties: any[];
  public divisions: any[];

   church : SaveChurch = {
    id: 0,
    archDioceseId: 0,
    dioceseId: 0,
    deaneryId: 0,
     divisionId: 0,
     countyId: 0,
     details: {
       name: "",
       fatherIncharge: "",
       addressLine: "",
       mailBox: "",
       website: ""

     }

  }


 

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private auth: AuthService,
    private churchService: ChurchService,
    private snackBarService: SnackbarService,
  ) {

 

  }
  ngOnInit() {
    this.churchService.getArchDioceses().subscribe(archDioceses => {
      this.archDioceses = archDioceses
      console.log("ARCHDIOCESES", this.archDioceses);
    });

    this.churchService.getCounties().subscribe(counties => {

      this.counties = counties
      console.log("Counties", this.counties);
    });



    this.churchService.getDivisions().subscribe(divisions => {
      this.divisions = divisions
      console.log("DIVISIONS", this.divisions);

    });

    

   
    





  }

  onArchDioceseChange() {
    let selectedArchDiocese = this.archDioceses.find(a => a.id == this.church.archDioceseId);

    this.dioceses = selectedArchDiocese.dioceses;

  //  console.log(`SELECTED: ${this.dioceses}`);
  }

  onDioceseChange() {
    let selectedDiocese = this.dioceses.find(d => d.id == this.church.dioceseId);
    this.deaneries = selectedDiocese.deaneries;
  //  console.log(`XDEANERIES: ${this.deaneries}`);
  }

  }



