import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {


  private readonly articleEndpoint = '/api/articles';


  constructor(  private http: HttpClient) { }


  getNewsEvents() {
    return this.http.get<any>('/api/newsandevents');
  }

  getCounties() {
    return this.http.get<any>('/api/counties');
  }

  create(article) {
    return this.http.post(this.articleEndpoint, article)

  }

  getArticle(id) {
    return this.http.get<any>(this.articleEndpoint + '/' + id);
  }

  getArticles() {
    return this.http.get<any>(this.articleEndpoint)
  }
  
}
