import { Component, inject } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { Post } from '../../Interfaces/Post';
import { InputTextModule } from 'primeng/inputtext';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { AccessService } from '../../services/access.service';
import { title } from 'process';
import { PostToUpdate } from '../../Interfaces/PostToUpdate';
import { PostService } from '../../services/post.service';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-post-edit',
  imports: [InputTextModule,ReactiveFormsModule,ButtonModule],
  templateUrl: './post-edit.component.html',
  styleUrl: './post-edit.component.css'
})
export class PostEditComponent {
  private postService = inject(PostService);
  public formBuild = inject(FormBuilder);

  public formUpdatePost: FormGroup = this.formBuild.group({
    title: ['', [Validators.required]],
    description: ['', Validators.required]
  });

  constructor(configDialog:DynamicDialogConfig, private ref: DynamicDialogRef){
    this.dataTrasnfer = configDialog.data;
    this.setDataPost();
  }

  dataTrasnfer:Post | undefined;

  setDataPost(){
    this.formUpdatePost.setValue({
      title:this.dataTrasnfer?.title,
      description:this.dataTrasnfer?.description
    })
  }
  UpdatePost() {
      if (this.formUpdatePost.invalid) {
        alert("Por favor, complete todos los campos correctamente.");
        return;
      }
  
      const postToUpdate: PostToUpdate = {
        postId: this.dataTrasnfer?.postId!,
        Tittle: this.formUpdatePost.value.title,
        Description: this.formUpdatePost.value.description
      };
  
      this.postService.UpdatePost(postToUpdate).subscribe({
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

    close(){
      this.ref.close(true);
    }

}
