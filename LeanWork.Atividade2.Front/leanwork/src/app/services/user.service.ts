import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getAllUsers(): Observable<any> {
    return this.http.get(environment.API_URL);
  }

  getUser(username: string) {
    return this.http.get(environment.API_URL + "/" + username);
  }

  getUserRepositories(username: string) {
    return this.http.get(environment.API_URL + "/" + username + "/repos");
  }
}
