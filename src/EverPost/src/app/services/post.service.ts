import { inject, Injectable } from '@angular/core';
import { appsettigns } from '../settings/appsettings';
import { HttpClient } from '@angular/common/http';
import { PaginatedData } from '../Interfaces/PaginatedData';
import { RequestPaginatedData } from '../Interfaces/RequestPaginatedData';
import { Observable } from 'rxjs';
import { BaseResponse } from '../Interfaces/BaseResponse';
import { Post } from '../Interfaces/Post';
import { UploadImage } from '../Interfaces/UploadImage';
import { PostCreateDto } from '../Interfaces/PostCreateDto';
import { PostToUpdate } from '../Interfaces/PostToUpdate';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private http = inject(HttpClient)
  private baseUrl:string = appsettigns.apiUrl;
  
  constructor() { }

  GetPosts(objeto:RequestPaginatedData): Observable<BaseResponse<PaginatedData<Post>>>{
      return this.http.post<BaseResponse<PaginatedData<Post>>>(`${this.baseUrl}Post/GetPosts`,objeto)    
  }

  AddPost(image:File, postToCreate: PostCreateDto): Observable<BaseResponse<Post>> {
    const formData: FormData = new FormData();
    

    formData.append('Archivo', image, image.name);

    formData.append('postToCreateJson', JSON.stringify(postToCreate));

    return this.http.post<BaseResponse<Post>>(`${this.baseUrl}Post/`, formData);
  }

  DeletePost(PostId:number): Observable<BaseResponse<string>>{
    return this.http.delete<BaseResponse<string>>(`${this.baseUrl}Post/${PostId}`)    
  }

  UpdatePost(postUpdateDto: PostToUpdate): Observable<BaseResponse<string>> {
    return this.http.put<BaseResponse<string>>(`${this.baseUrl}Post/`, postUpdateDto);
  }
}
