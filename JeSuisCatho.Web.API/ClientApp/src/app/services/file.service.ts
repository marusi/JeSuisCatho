import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class FileService {

 

  constructor(private http: HttpClient) {

  }

  uploadDoc(productId, document) {
    const formData = new FormData();
    formData.append('file', document);
    return this.http.post(`/api/products/${productId}/documents`, formData);
    
  }
  uploadPhoto(productId, photo) {
    const formData = new FormData();
    formData.append('file', photo);
    return this.http.post(`/api/products/${productId}/photos`, formData);
  }

  getPhotos(productId) {
    return this.http.get<[]>(`/api/products/${productId}/photos`);
  }

  getDocuments(productId) {
    return this.http.get<[]>(`/api/products/${productId}/documents`);
  }

}
