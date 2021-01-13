
import { Component, OnInit, ViewChild } from '@angular/core';
import { AddEvent, GridComponent, CellClickEvent, PageChangeEvent, GridDataResult } from '@progress/kendo-angular-grid';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ItemService } from '../services/item.service'
import { Item } from './item';
import { unitcosts } from './unitCosts';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { State, process } from '@progress/kendo-data-query';
@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  public Items: Item[];
  public formGroup: FormGroup;
  public gridView: GridDataResult;
  public pageSize = 10;
  public skip = 0;
  public unitcosts: any[] = unitcosts;
  public gridState: State = {
    sort: [],
    skip: 0,
    take: 10

  };


  public view: Observable<GridDataResult>;
  @ViewChild(GridComponent,{ static: true }) private grid: GridComponent;
  private editedRowIndex: number;
  private isNew = false;
  constructor(private formBuilder: FormBuilder, private _itemService: ItemService) { }

  public ngOnInit(): void {
    this.view = this._itemService.pipe(map((data: any) => process(data, this.gridState)));
    this._itemService.read();
  }
  public onStateChange(state: State) {
    this.gridState = state;
    this._itemService.read();
  }
  public cellClickHandler({ sender, rowIndex, columnIndex, dataItem, isEdited }) {
    debugger;
    if (!isEdited) {
      sender.editCell(rowIndex, columnIndex, this.createFormGroup(dataItem));
    }
  }

  public cellCloseHandler(args: any) {
    debugger;
    const { formGroup, dataItem } = args;

    if (!formGroup.valid) {
      // prevent closing the edited cell if there are invalid values.
      args.preventDefault();
    } else if (formGroup.dirty) {
      this._itemService.assignValues(dataItem, formGroup.value);
      this._itemService.update(dataItem);
    }
  }

  public addHandler({ sender }) {
    debugger;
    sender.addRow(this.createFormGroup(new Item()));
  }

  public cancelHandler({ sender, rowIndex }) {
    debugger;
    sender.closeRow(rowIndex);
  }

  public saveHandler({ sender, formGroup, rowIndex }) {
    debugger;

    if (formGroup.valid) {
      this._itemService.create(formGroup.value);
     sender.closeRow(rowIndex);
    }
  }

  public removeHandler({ sender, dataItem }) {
    debugger;
    this._itemService.remove(dataItem);
    sender.cancelCell();
  }

  public saveChanges(grid: any): void {
    debugger;
    grid.closeCell();
    grid.cancelCell();

   this._itemService.saveChanges();
     
 
  }

  public cancelChanges(grid: any): void {
    debugger;
    grid.cancelCell();
  this._itemService.cancelChanges();
  }
  public findUnitCost(id: number): any {
    debugger;
    var test =this.unitcosts.find(x => x.unitCostID === id);
    return this.unitcosts.find(x => x.unitCostID === id);
  }
  public createFormGroup(dataItem: Item): FormGroup {
    debugger;
    return this.formBuilder.group({
      'invItemId': dataItem.invItemId,
      'name': dataItem.name,
      'itemNumber': dataItem.itemNumber,
      'unitCostID': dataItem.unitCostID
    });
  }

}

