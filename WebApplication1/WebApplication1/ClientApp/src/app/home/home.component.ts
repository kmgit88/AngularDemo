import { Component } from '@angular/core';
import { RserviceService } from '../rservice.service'
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  data: any;
  constructor(private RserviceService: RserviceService) { }


  ngOnInit(): void {
    debugger;
    this.getdata();
  }
  getdata() {
    debugger;
    this.RserviceService.getData().subscribe((data: any[]) => {
      debugger;
      this.data = data;
    })
  }
}
