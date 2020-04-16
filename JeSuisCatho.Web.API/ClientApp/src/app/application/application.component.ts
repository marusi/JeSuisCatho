import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-application-component',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.css']
})

export class ApplicationsComponent implements OnInit {

  isExpanded = false;
  fileUrl;
  constructor(private sanitizer: DomSanitizer) { }
  ngOnInit() {
    const data = 'some text';
    const blob = new Blob([data], { type: 'application/octet-stream' });

    this.fileUrl = this.sanitizer.bypassSecurityTrustResourceUrl(window.URL.createObjectURL(blob));
  }
 
}
