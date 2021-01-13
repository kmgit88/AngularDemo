import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RserviceService {
  //baseurl: "https://localhost:44321"
  baseurl: string = "https://localhost:44321";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })

  }
  getData() {
    debugger;
    //var baseurl: "https://localhost:44321"
    const endpointUrl = `${this.baseurl}${environment.apiUrls.reports.getData}`;

    return this.http.get(endpointUrl);  //https://localhost:44352/ webapi host url  
  }  
}
