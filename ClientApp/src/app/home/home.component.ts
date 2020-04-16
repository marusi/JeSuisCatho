import { Component } from '@angular/core';

export interface Section {
  name: string;
  updated: Date;
}

export interface Novena {
  name: string;
  position: number;
  starts: string;
  feastday: string;
}

const ELEMENT_DATA: Novena[] = [
  { position: 1, name: 'Surrender', starts: 'January 2nd', feastday: 'January 11th' },
  { position: 2, name: 'Infant of Prague', starts: 'January 5th', feastday: 'January 14th' },
  { position: 3, name: 'St. Agnes', starts: 'January 12th', feastday: 'January 21st' },
  { position: 4, name: 'St. Francis de Sales', starts: 'January 15th', feastday: 'January 24th' },

];

@Component({
  selector: 'app-home-component',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  folders: Section[] = [
    {
      name: 'Marriage',
      updated: new Date('1/1/16'),
    },
    {
      name: 'Holy Communion',
      updated: new Date('1/17/16'),
    },
    {
      name: 'Baptism',
      updated: new Date('1/28/16'),
    }
  ];
  notes: Section[] = [
    {
      name: 'United against Corruption',
      updated: new Date('2/20/16'),
    },
    {
      name: 'Prayers for Corona virus victims',
      updated: new Date('1/18/16'),
    },
    {
      name: 'Prayers for South Sudan',
      updated: new Date('12/18/19'),
    }
  ];




  



  showCard() {
    const btn = document.getElementById("btn");
    const second = document.getElementById("second");
     btn.classList.toggle("is-rotate");
      second.classList.toggle("is-visible");
      }

 

}
