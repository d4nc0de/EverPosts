import { Component, inject } from '@angular/core';
import { CardModule } from 'primeng/card';
import { Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { PasswordModule } from 'primeng/password';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputTextModule } from 'primeng/inputtext';
import { AccessService } from '../../services/access.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { User } from '../../Interfaces/User';

@Component({
  selector: 'app-register',
  imports: [CardModule,ButtonModule, PasswordModule,InputGroupModule,InputGroupAddonModule,InputTextModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accesService = inject(AccessService);
  private router = inject(Router);
  public formBuild = inject(FormBuilder);
  loginImagePath = '../../Images/LoginImage.jpg'; 
  
  public formRegister: FormGroup = this.formBuild.group({
    userName: ['', [Validators.required]],
    correo: ['', [Validators.required, Validators.email]],
    clave: ['', Validators.required]
  });

  register(){
    if (this.formRegister.invalid) {
      alert("Por favor, complete todos los campos correctamente.");
      return;
    }

    const objeto:User = {
      Name: this.formRegister.value.userName,
      Mail: this.formRegister.value.correo,
      Pass: this.formRegister.value.clave
    }
    this.accesService.register(objeto).subscribe({
      next: (data) =>{
        if(data.success){
          this.router.navigate(['Home/Post']);
        }else{
          alert("No fue posible realizar el registro.");
        }
      },
      error: (error) => {
        alert("Error al registrarse")
      }
    })  
  }
  
  volver(){
    this.router.navigate(['']);
  }
}
