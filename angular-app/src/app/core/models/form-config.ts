export interface FormField {
  field: string;
  label: string;
  type: 'text' | 'number' | 'date' | 'select';
  options?: SelectOption[];
}

export interface SelectOption {
  key: string;
  value: string;
}
