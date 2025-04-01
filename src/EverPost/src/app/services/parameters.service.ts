import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseResponse } from '../Interfaces/BaseResponse';
import { appsettigns } from '../settings/appsettings';
import { Categorie } from '../Interfaces/Categorie';

@Injectable({
  providedIn: 'root'
})
export class ParametersService {

  private http = inject(HttpClient);
  private baseUrl: string = appsettigns.apiUrl;

  constructor() { }

  GetCategories(): Observable<BaseResponse<Categorie[]>> {
    return this.http.get<BaseResponse<Categorie[]>>(`${this.baseUrl}Post/Categorie`);
  }
}
