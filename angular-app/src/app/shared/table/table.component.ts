import {Component, Input} from '@angular/core';
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
}
