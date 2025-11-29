import {Component, inject} from '@angular/core';
import {AuthService} from '../../../core/services/auth.service';
import {Router, RouterLink} from '@angular/router';
import {FormBuilder, ReactiveFormsModule, Validators} from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './login.component.html',
  standalone: true
})
export class LoginComponent {
  private authService = inject(AuthService);
  private router = inject(Router);
  private fb = inject(FormBuilder);

  error = '';

  form = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]]
  });

  onSubmit() {
    if (this.form.invalid) return;

    const { email, password } = this.form.value;

    this.authService.login(email!, password!).subscribe({
      next: () => {
        this.router.navigate(['/grids/transport'])
        this.error = '';
        console.log('login success');
      },
      error: (err) => {
        if (err.status === 404) {
          this.error = 'Ендпоінт для входу не знайдено. Зверніться до служби підтримки';
        } else if (err.status === 401) {
          this.error = 'Невірний email або пароль.';
        } else {
          this.error = 'Сталася непередбачена помилка.';
        }
      }
    });
  }
}
