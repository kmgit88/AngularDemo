
//import { Component, OnInit, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
//import { ChildComponent } from "../parent/child/child.component"
//@Component({
//  selector: 'app-parent',
//  templateUrl: './parent.component.html',
//  styleUrls: ['./parent.component.css']
//})
//export class ParentComponent implements  OnInit {
//  //@ViewChild(ChildComponent, { static: false }) private child: ChildComponent;
// // @ViewChild(ChildComponent, { static: true }) child: ChildComponent;
// @ViewChild(ChildComponent) child: ChildComponent;
//  constructor() { }

//  AccessChildMessage: any;
//  parentMessage = "Message From Parent";

//  //ngAfterViewInit() {
//  //  debugger;
//  // this.AccessChildMessage = this.child.childData;
//  //}
//  ngOnInit() {
//    debugger;
//    this.AccessChildMessage = this.child;
//  }

//}



import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { ChildComponent } from "../parent/child/child.component"

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.css']
})
export class ParentComponent implements OnInit, AfterViewInit {

  @ViewChild(ChildComponent) child;
  public message: string;

  constructor() { }

  ngOnInit() {
    debugger;
    this.message = this.child.childData;
  }
  ngAfterViewInit() {
    this.message = this.child.childData;
  }
}
