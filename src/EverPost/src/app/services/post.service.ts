import { inject, Injectable } from '@angular/core';
import { appsettigns } from '../settings/appsettings';
import { HttpClient } from '@angular/common/http';
import { PaginatedData } from '../Interfaces/PaginatedData';
import { RequestPaginatedData } from '../Interfaces/RequestPaginatedData';
import { Observable } from 'rxjs';
import { BaseResponse } from '../Interfaces/BaseResponse';
import { Post } from '../Interfaces/Post';
import { UploadImage } from '../Interfaces/UploadImage';
import { PostCreateDto } from '../Interfaces/PostToCreate';
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

  AddPost(image: UploadImage, postToCreate: PostCreateDto): Observable<BaseResponse<Post>> {
    const formData: FormData = new FormData();
    

    formData.append('image', image.file, image.file.name);

    formData.append('postToCreateJson', JSON.stringify(postToCreate));

    return this.http.post<BaseResponse<Post>>(`${this.baseUrl}Post/AddPost`, formData);
  }

  DeletePost(PostId:number): Observable<BaseResponse<string>>{
    return this.http.delete<BaseResponse<string>>(`${this.baseUrl}Post/${PostId}`)    
  }

  UpdatePost(postUpdateDto: PostToUpdate): Observable<BaseResponse<string>> {
    return this.http.put<BaseResponse<string>>(`${this.baseUrl}Post/`, postUpdateDto);
  }
}
