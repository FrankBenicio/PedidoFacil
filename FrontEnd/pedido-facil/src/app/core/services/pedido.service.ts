import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { environment } from './environment';
import { ApiResponse } from '../models/api-response.model';
import { CreatePedidoRequest, PedidoResponse, PedidoStatus, UpdatePedidoStatusRequest } from '../models/pedido.model';

@Injectable({ providedIn: 'root' })
export class PedidoService {
  private readonly url = `${environment.apiUrl}/pedidos`;

  constructor(private readonly http: HttpClient) {}

  listar(status?: PedidoStatus | null): Observable<PedidoResponse[]> {
    let params = new HttpParams();
    if (status) params = params.set('status', status.toString());

    return this.http.get<ApiResponse<PedidoResponse[]>>(this.url, { params }).pipe(map(r => r.Data));
  }

  obterPorId(id: string): Observable<PedidoResponse> {
    return this.http.get<ApiResponse<PedidoResponse>>(`${this.url}/${id}`).pipe(map(r => r.Data));
  }

  criar(request: CreatePedidoRequest): Observable<ApiResponse<string>> {
    return this.http.post<ApiResponse<string>>(this.url, request);
  }

  atualizarStatus(id: string, request: UpdatePedidoStatusRequest): Observable<ApiResponse<unknown>> {
    return this.http.patch<ApiResponse<unknown>>(`${this.url}/${id}/status`, request);
  }
}
