import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RserviceService } from './rservice.service';
import { UserListComponent } from './user-list/user-list.component';
import { ItemComponent } from './item/item.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ParentComponent } from './parent/parent.component';
import { ChildComponent } from './Parent/child/child.component';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';


  
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    UserListComponent,
    ItemComponent,
    ParentComponent,
    ChildComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'item-data', component: ItemComponent },
      { path: 'parent-child', component: ParentComponent },
    ]),
    GridModule,
    BrowserAnimationsModule,
    DropDownsModule,
    ReactiveFormsModule
  ],
  providers: [RserviceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
