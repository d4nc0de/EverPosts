import { Component, inject, OnInit } from '@angular/core';
import { CarouselModule } from 'primeng/carousel';
import { TagModule } from 'primeng/tag';
import { ButtonModule } from 'primeng/button';
import { PostService } from '../../services/post.service';
import { Post } from '../../Interfaces/Post';
import { RequestPaginatedData } from '../../Interfaces/RequestPaginatedData';
import { BaseResponse } from '../../Interfaces/BaseResponse';
import { PaginatedData } from '../../Interfaces/PaginatedData';

@Component({
  selector: 'app-list-posts',
  imports: [CarouselModule,TagModule,ButtonModule],
  templateUrl: './list-posts.component.html',
  styleUrl: './list-posts.component.css',
  providers: [PostService],
})
export class ListPostsComponent implements OnInit{
  public Posts:Post[] = [];


  constructor(private postService: PostService) {}
  
  ngOnInit(){

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
  
}
