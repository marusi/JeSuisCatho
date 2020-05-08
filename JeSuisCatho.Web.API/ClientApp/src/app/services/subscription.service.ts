import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Profile } from '../models/profile';

@Injectable({
  providedIn: 'root'
})
export class SubscriptionService {

  userData = new BehaviorSubject<Profile>(new Profile());



  constructor() { }
}
