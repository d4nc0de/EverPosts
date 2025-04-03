import { Component, inject, OnInit } from '@angular/core';
import { CarouselModule } from 'primeng/carousel';
import { TagModule } from 'primeng/tag';
import { ButtonModule } from 'primeng/button';
import { PostService } from '../../services/post.service';
import { Post } from '../../Interfaces/Post';
import { RequestPaginatedData } from '../../Interfaces/RequestPaginatedData';
import { DialogModule } from 'primeng/dialog';
import { PostEditComponent } from '../post-edit/post-edit.component';
import { DialogService, DynamicDialogModule, DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-list-posts',
  imports: [CarouselModule,TagModule,ButtonModule,DialogModule,DynamicDialogModule],
  templateUrl: './list-posts.component.html',
  styleUrl: './list-posts.component.css',
  providers: [PostService,DialogService],
})
export class ListPostsComponent implements OnInit{
  public Posts:Post[] = [];
  ref: DynamicDialogRef | undefined;

  constructor(private postService: PostService, public dialogService: DialogService) {}
  
  ngOnInit(){
    this.GetPost();
  }

  GetPost(){
    const objeto:RequestPaginatedData = {
      filterId:0,
      Page:1,
      PageSize:10
    }

    this.postService.GetPosts(objeto).subscribe({
      next:(data)=>{
        if(data.success != false){
          this.Posts = data.data.data
        }
      }
    
    });
  }

  DeletePost(id:number){
    this.postService.DeletePost(id).subscribe({
      next:(data)=>{
        if(data.success == false){
          alert(data.message);
        }
        this.Posts = this.Posts.filter(post => post.postId !== id);
      }
    });
  }
  show(post:Post) {
    const isMobileOrTablet = window.innerWidth <= 768;
 
    let widthResponsive;
    if (isMobileOrTablet) {
      widthResponsive = '90%';
    } else {
      widthResponsive = '40%';
    }
    
    this.ref = this.dialogService.open(PostEditComponent, {
        header: 'Editar Post',
        width: widthResponsive,
        data:post,
        contentStyle: { overflow: 'auto' },
        baseZIndex: 10000,
        closable: true
    });

    this.ref.onClose.subscribe((respone: boolean) => {
        if (respone) {
            this.GetPost();
        }
    });
  }


}
