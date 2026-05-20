import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { environment } from './environment';
import { ApiResponse } from '../models/api-response.model';
import { CreateProdutoRequest, ProdutoResponse, UpdateProdutoRequest } from '../models/produto.model';

@Injectable({ providedIn: 'root' })
export class ProdutoService {
  private readonly url = `${environment.apiUrl}/produtos`;

  constructor(private readonly http: HttpClient) {}

  listar(): Observable<ProdutoResponse[]> {
    return this.http.get<ApiResponse<ProdutoResponse[]>>(this.url).pipe(map(r => r.Data));
  }

  obterPorId(id: string): Observable<ProdutoResponse> {
    return this.http.get<ApiResponse<ProdutoResponse>>(`${this.url}/${id}`).pipe(map(r => r.Data));
  }

  criar(request: CreateProdutoRequest): Observable<ApiResponse<string>> {
    return this.http.post<ApiResponse<string>>(this.url, request);
  }

  atualizar(id: string, request: UpdateProdutoRequest): Observable<ApiResponse<unknown>> {
    return this.http.put<ApiResponse<unknown>>(`${this.url}/${id}`, request);
  }

  remover(id: string): Observable<ApiResponse<unknown>> {
    return this.http.delete<ApiResponse<unknown>>(`${this.url}/${id}`);
  }
}
