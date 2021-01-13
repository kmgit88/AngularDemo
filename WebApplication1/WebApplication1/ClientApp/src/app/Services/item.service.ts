import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';
import { Item } from '../item/item';
import { State } from '@progress/kendo-data-query';
import { map } from 'rxjs/operators';

const CREATE_ACTION = 'create';
const UPDATE_ACTION = 'update';
const REMOVE_ACTION = 'destroy';
const itemIndex = (item: any, data: any[]): number => {
  for (let idx = 0; idx < data.length; idx++) {
    if (data[idx].invItemId === item.invItemId) {
      return idx;
    }
  }
  return -1;
};

const cloneData = (data: any[]) => data.map(item => Object.assign({}, item));

@Injectable({
  providedIn: 'root'
})
export class ItemService extends BehaviorSubject<any[]> {
  header = new HttpHeaders({ "content-type": "application/json" });
  myAppUrl: string = "";
  baseurl: string = "https://localhost:44321/";

  private data: any[] = [];
  private originalData: any[] = [];
  public createdItems: Item[] = [];
  private deletedItems: Item[] = [];
  public updatedItems: Array<Item> = [];
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super([]);
  }
  public read() {
    if (this.data.length) {
      return super.next(this.data);
    }

    this.fetch()
      .subscribe(data => {
        this.data = data;
        this.originalData = cloneData(data);
        super.next(data);
      });
  }
  public getItems(): Observable<any> {
    debugger;
    let endpointUrl = this.baseurl + 'api/Item/Index';
    return this.http.get(endpointUrl, {
      headers: this.header,
      responseType: "json",
    });
  }

  public getItemsNew(data: State): Observable<any> {
    debugger;
    let endpointUrl = this.baseurl + 'api/Item/Index';
    return this.http.post(endpointUrl, data, { headers: this.header }).pipe(
      map((response: any) => {
        return response;
      })
    );

  }
  getEmployeeById(id: number) {
    return this.http.get<any[]>(this.myAppUrl + "api/Item/Details/" + id);
  }

  public saveItem(data: Item[]) {
    debugger;
    var url = this.baseurl + 'api/Item/Create';
    const headers = { 'content-type': 'application/json' }
    this.http.post(url, data, { 'headers': headers })
      .subscribe(result => { alert("Posted" + JSON.stringify(result)); }, error => console.error(error));

  }

  public updateItem(data: Item[]) {
    var url = this.baseurl + 'api/Item/Edit';
    const headers = { 'content-type': 'application/json' }
    this.http.post(url, data, { 'headers': headers })
      .subscribe(result => { alert("Posted" + JSON.stringify(result)); }, error => console.error(error));  

  }


  deleteItem(data: Item[]) {
    debugger;
  //  return this.http.delete<any[]>(this.myAppUrl + "api/Item/Delete/" + id);
    var url = this.baseurl + 'api/Item/Delete';
    const headers = { 'content-type': 'application/json' }
    this.http.post(url, data, { 'headers': headers })
      .subscribe(result => { alert("Posted" + JSON.stringify(result)); }, error => console.error(error));  
  }

  //errorHandler(error: Response) {
  //  console.log(error);
  //  return Observable.throw(error);
  //}
  public isNew(item: any): boolean {
    debugger;
    return !item.invItemId;
  }

  public hasChanges(): boolean {
    return Boolean(this.deletedItems.length || this.updatedItems.length || this.createdItems.length);
  }
  public create(item: any): void {
    debugger;
    this.createdItems.push(item);
    this.data.unshift(item);

    super.next(this.data);
  }
  public update(item: any): void {
    if (!this.isNew(item)) {
      const index = itemIndex(item, this.updatedItems);
      if (index !== -1) {
        this.updatedItems.splice(index, 1, item);
      } else {
        this.updatedItems.push(item);
      }
    } else {
      const index = this.createdItems.indexOf(item);
      this.createdItems.splice(index, 1, item);
    }
  }

  public remove(item: any): void {
    let index = itemIndex(item, this.data);
    this.data.splice(index, 1);

    index = itemIndex(item, this.createdItems);
    if (index >= 0) {
      this.createdItems.splice(index, 1);
    } else {
      this.deletedItems.push(item);
    }

    index = itemIndex(item, this.updatedItems);
    if (index >= 0) {
      this.updatedItems.splice(index, 1);
    }

    super.next(this.data);
  }
  public saveChanges(): void {
    debugger;
    if (!this.hasChanges()) {
      return;
    }

    const completed = [];
    if (this.deletedItems.length) {
      //completed.push(this.fetch(REMOVE_ACTION, this.deletedItems));
      this.deleteItem(this.deletedItems);
    }
    if (this.updatedItems.length) {
      this.updateItem(this.updatedItems)
    }
    if (this.createdItems.length) {
      //completed.push(this.fetch(CREATE_ACTION, this.createdItems));
      this.saveItem(this.createdItems)
    }
    this.reset();
    this.getItems();
  }

  public cancelChanges(): void {
    this.reset();
    this.data = this.originalData;
    this.originalData = cloneData(this.originalData);
    super.next(this.data);
  }

  public assignValues(target: any, source: any): void {
    Object.assign(target, source);
  }

  private reset() {
    this.data = [];
    this.deletedItems = [];
    this.updatedItems = [];
    this.createdItems = [];
  }

  private fetch(action: string = '', data?: any): Observable<any[]> {
  //  return this.http
  //    .jsonp(`https://demos.telerik.com/kendo-ui/service/Products/${action}?${this.serializeModels(data)}`, 'callback')
  //    .pipe(map(res => <any[]>res));
    return this.getItems();
  }

  private serializeModels(data?: any): string {
    return data ? `&models=${JSON.stringify(data)}` : '';
  }
}
