export interface FormField {
  field: string;
  label: string;
  type: 'text' | 'number' | 'date' | 'select';
  options?: string[];
  validators?: any[];
}
