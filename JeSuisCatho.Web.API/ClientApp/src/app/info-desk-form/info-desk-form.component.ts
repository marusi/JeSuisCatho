import { Component, OnInit } from '@angular/core';
import { ArticleService } from './../services/article.service';




import { SnackbarService } from '../services/snackbar.service';
import { Router, ActivatedRoute } from '@angular/router';





@Component({
  selector: 'app-info-desk-form',
  templateUrl: './info-desk-form.component.html',
  styleUrls: ['./info-desk-form.component.css']
})
export class InfoDeskFormComponent implements OnInit {



  private newsandevents: any[];
  private newsCategories: any[];
  private counties: any[];
  

  private article = {
    id: 0,
    newsEventId: 0,
    newsCategoryId: 0,
    isInvited: false,
    counties: [],
  
    ambaco: {
      title: '',
      subTitle: '',
      body: '',
      dateOfEvent: '',
      duration: '',
    }
  };

  


  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private articleService: ArticleService,
    private snackBarService: SnackbarService
  ) {
   
    route.params.subscribe(p => {
      this.article.id = +p['id'] || 0;
    });
  }



 





  ngOnInit(): void {

    this.articleService.getArticle(this.article.id)
      .subscribe(a => {
        this.article = a;
      }, err => {
          if (err.status == 404)
            this.snackBarService.showSnackBar('Unable to create and article');
           // this.router.navigate(['/not-found-error'])
      });

    this.articleService.getNewsEvents().subscribe(newsandevents => 
      this.newsandevents = newsandevents);

  // console.log("NEWSANDEVENTS", this.newsandevents);



    this.articleService.getCounties().subscribe(counties => {

      this.counties = counties
      console.log("Counties", this.counties);
    });

  }

    
  
  

  onNewsEventChange() {
    //
   // console.log("Articles", this.article)
    let selectedNewsandEvent = this.newsandevents.find(n => n.id == this.article.newsEventId);

    this.newsCategories = selectedNewsandEvent.newsCategories;
  }


  onCountyToggle(countyId, $event) {
    if ($event.target.checked)
      this.article.counties.push(countyId);
    else {
      let index = this.article.counties.indexOf(countyId);
      this.article.counties.splice(index, 1);
    }

  }

  submitArticle() {
    this.articleService.create(this.article)
      .subscribe(x => {
        this.snackBarService.showSnackBar('Article created succesfully');
        
      });
  }
 
 


}
