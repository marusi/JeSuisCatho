
import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../services/article.service';
// import { Router, ActivatedRoute } from '@angular/router';
// import 'rxjs/observable/ForkJoinObservable';
import { SnackbarService } from '../services/snackbar.service';
import { KeyValuePair, Article } from '../models/article';

@Component({
  selector: 'app-article-list',
  styleUrls: ['article-list.component.css'],
  templateUrl: 'article-list.component.html'
})
export class ArticleListComponent implements OnInit {
  

  articles: any = { };

  newsEvents: KeyValuePair[];
  counties: KeyValuePair[];




  constructor(private articleService: ArticleService, private snackBarService: SnackbarService) { }

  ngOnInit() {

    this.articleService.getNewsEvents()
      .subscribe(newsEvents => this.newsEvents = newsEvents);

    this.articleService.getCounties()
      .subscribe(counties => this.counties = counties);

    this.populateArticles();

  }

  populateArticles() {

    this.articleService.getArticles().subscribe(result => {
      this.articles = result;

     
     
    }, error => console.log(error));

  }








}
