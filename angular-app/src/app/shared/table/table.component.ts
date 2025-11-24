import {Component, EventEmitter, Input, Output} from '@angular/core';
import {TableColumn} from '../../core/models/table-config';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  standalone: true
})
export class TableComponent {
  @Input() title = '';
  @Input() columns: TableColumn[] = [];
  @Input() data: any[] | null = [];
  @Input() canCrud: boolean = false;

  @Output() edit = new EventEmitter<any>();
  @Output() delete = new EventEmitter<any>();

  onEdit(row: any) {
    this.edit.emit(row);
  }

  onDelete(row: any) {
    this.delete.emit(row);
  }
}
