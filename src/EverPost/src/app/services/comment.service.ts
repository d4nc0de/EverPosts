import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { appsettigns } from '../settings/appsettings';
import { BaseResponse } from '../Interfaces/BaseResponse';
import { Comment } from '../Interfaces/Comment';
import { CommentToCreate } from '../Interfaces/CommentToCreate';
import { PaginatedData } from '../Interfaces/PaginatedData';
import { RequestPaginatedData } from '../Interfaces/RequestPaginatedData';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private http = inject(HttpClient)
  private baseUrl:string = appsettigns.apiUrl;
  constructor() { }

  GetComments(paginatorDto: RequestPaginatedData): Observable<BaseResponse<PaginatedData<Comment>>> {
    return this.http.get<BaseResponse<PaginatedData<Comment>>>(`${this.baseUrl}Comment`, { params: paginatorDto as any });
  }

  // Método para crear un comentario
  CreateComment(commentToCreate: CommentToCreate): Observable<BaseResponse<Comment>> {
    return this.http.post<BaseResponse<Comment>>(`${this.baseUrl}Comment`, commentToCreate);
  }
}
