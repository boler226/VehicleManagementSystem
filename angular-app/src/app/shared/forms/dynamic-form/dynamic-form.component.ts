import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormField} from '../../../core/models/form-config';
import {FormBuilder, FormGroup, ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-dynamic-form',
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './dynamic-form.component.html',
  standalone: true
})
export class DynamicFormComponent implements OnInit {
  @Input() fields: FormField[] = [];
  @Input() initialData: any = {};
  @Output() save = new EventEmitter<any>();

  form!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    const group: any = {};
    this.fields.forEach(f => {
      group[f.field] = [this.initialData[f.field] || ''];
    });
    this.form = this.fb.group(group);
  }

  onSubmit() {
    if (this.form.valid) {
      this.save.emit(this.form.value);
    }
  }
}
