import { Component,inject, OnInit } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { Post } from '../../Interfaces/Post';
import { InputTextModule } from 'primeng/inputtext';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { AccessService } from '../../services/access.service';
import { title } from 'process';
import { PostToUpdate } from '../../Interfaces/PostToUpdate';
import { PostService } from '../../services/post.service';
import { ButtonModule } from 'primeng/button';
import { FileUploadModule } from 'primeng/fileupload';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { PostCreateDto } from '../../Interfaces/PostCreateDto';
import { ParametersService } from '../../services/parameters.service';
import { MultiSelectModule } from 'primeng/multiselect';
import { Categorie } from '../../Interfaces/Categorie';

interface UploadEvent {
  originalEvent: Event;
  files: File[];
}

@Component({
  selector: 'app-post-create',
  imports: [InputTextModule,ReactiveFormsModule,ButtonModule, FileUploadModule,ToastModule, MultiSelectModule],
  templateUrl: './post-create.component.html',
  styleUrl: './post-create.component.css',
  providers:[MessageService]
})
export class PostCreateComponent implements OnInit {
  private postService = inject(PostService);
  private parametersService = inject(ParametersService);
  public formBuild = inject(FormBuilder);
  uploadedFiles: any[] = [];
  Categories: Categorie[] = [];

  ngOnInit(): void {
    this.getCategories();
  }

  public formCreatePost: FormGroup = this.formBuild.group({
    title: ['', [Validators.required]],
    description: ['', Validators.required],
    selectedCategories:['', Validators.required]
  });

  constructor(private ref: DynamicDialogRef, private messageService: MessageService){}

  CreatePost() {
    if (this.formCreatePost.invalid || this.uploadedFiles.length < 1) {
      alert("Por favor, complete todos los campos correctamente.");
      return;
    }
    
    const postToCreate:PostCreateDto = 
    {
      UserId: 1,
      Tittle: this.formCreatePost.value.title,
      Description: this.formCreatePost.value.description,
      Route: '',
      Categories: []
    } 
    this.postService.AddPost(this.uploadedFiles[this.uploadedFiles.length - 1],postToCreate).subscribe({
      next: (data) => {
        if (data.success) {
          alert("Editado correctamente");
          this.ref.close(true);
        } else {
          alert("Error al editar.");
        }
      },
      error: (error) => {
        console.log("Error en el login:", error.message);
      }
    });
      
  }
  onUpload(event:any) {
    for(let file of event.files) {
        this.uploadedFiles.push(file);
    }
    
    this.messageService.add({severity: 'info', summary: 'File Uploaded', detail: ''});
}
  getCategories(){
    this.parametersService.GetCategories().subscribe({
      next: (data) => {
        if (!data.success) {
          alert("Error al Cargar categorias.");
        }else{
          this.Categories = data.data;
        }
      },
      error: (error) => {
        console.log("Error en el login:", error.message);
      }
    });
  }
}
    
