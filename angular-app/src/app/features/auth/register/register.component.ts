import {Component, inject} from '@angular/core';
import {FormBuilder, ReactiveFormsModule, Validators} from '@angular/forms';
import {AuthService} from '../../../core/services/auth.service';
import {Router} from '@angular/router';
import {User} from '../../../core/models/user';

@Component({
  selector: 'app-register',
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './register.component.html',
  standalone: true
})
export class RegisterComponent {
  private authService = inject(AuthService);
  private router = inject(Router);
  private fb = inject(FormBuilder);

  error = '';
  success = '';

  form = this.fb.group({
    userName: ['', [Validators.required, Validators.minLength(3)]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
    confirmPassword: ['', [Validators.required, Validators.minLength(6)]],
    fullName: ['', Validators.required],
    role: ['Guest']
  });

  onSubmit() {
    if (this.form.invalid) return;

    const { email, password, confirmPassword, fullName, userName, role } = this.form.value;

    if (password !== confirmPassword) {
      this.error = 'Passwords do not match';
      return;
    }

    const user: User = {
      userName: this.form.value.userName!,
      email: this.form.value.email!,
      password: this.form.value.password!,
      fullName: this.form.value.fullName!,
      role: this.form.value.role!
    };

    this.authService.register(user).subscribe({
      next: () => {
        this.success = 'Registration successful!';
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error(err);
        if (err.status === 400) {
          this.error = 'Invalid registration data. Please check your inputs.';
        } else {
          this.error = 'Registration failed. Try again later.';
        }
      }
    });
  }
}
