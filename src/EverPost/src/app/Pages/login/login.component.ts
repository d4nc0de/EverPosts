import { Component, inject } from '@angular/core';
import { AccessService } from '../../services/access.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Login } from '../../Interfaces/Login';

import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { PasswordModule } from 'primeng/password';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CardModule, ButtonModule, ReactiveFormsModule, PasswordModule, InputGroupModule, InputGroupAddonModule,InputTextModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  private accesService = inject(AccessService);
  private router = inject(Router);
  public formBuild = inject(FormBuilder);
  loginImagePath = '../../Images/LoginImage.jpg'; 
  
  public formLogin: FormGroup = this.formBuild.group({
    correo: ['', [Validators.required, Validators.email]],
    clave: ['', Validators.required]
  });

  Login() {
    if (this.formLogin.invalid) {
      alert("Por favor, complete todos los campos correctamente.");
      return;
    }

    const credentials: Login = {
      Mail: this.formLogin.value.correo,
      Pass: this.formLogin.value.clave
    };

    this.accesService.login(credentials).subscribe({
      next: (data) => {
        if (data.success) {
          localStorage.setItem("token", data.data);
          this.router.navigate(['Home/Post']);
        } else {
          alert("Credenciales incorrectas.");
        }
      },
      error: (error) => {
        console.log("Error en el login:", error.message);
      }
    });
  }

  register() {
    this.router.navigate(['Register']);
  }
}
