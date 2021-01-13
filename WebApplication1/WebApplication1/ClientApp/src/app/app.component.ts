import { Component } from '@angular/core';
import { RserviceService } from './rservice.service'; 
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  data: any; 
  constructor(private RserviceService: RserviceService) { }  

  ngOnInit(): void {
    //this.getdata();
  }
  getdata() {
    debugger;
    this.RserviceService.getData().subscribe((data: any[]) => {
      debugger;
      this.data = data;
    })
  }  
}
