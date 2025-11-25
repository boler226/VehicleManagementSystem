import {Component, ContentChild, EventEmitter, Input, Output, TemplateRef} from '@angular/core';
import {TableColumn} from '../../core/models/table-config';
import {NgTemplateOutlet} from '@angular/common';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  imports: [
    NgTemplateOutlet
  ],
  standalone: true
})
export class TableComponent {
  @Input() title = '';
  @Input() columns: TableColumn[] = [];
  @Input() data: any[] | null = [];

  @Input() canCrud: boolean = false;
  @Input() showCrud: boolean = true;

  @Output() edit = new EventEmitter<any>();
  @Output() delete = new EventEmitter<any>();

  @ContentChild('actions', { static: false }) actionsTemplate?: TemplateRef<any>;

  onEdit(row: any) {
    this.edit.emit(row);
  }

  onDelete(row: any) {
    this.delete.emit(row);
  }
}
