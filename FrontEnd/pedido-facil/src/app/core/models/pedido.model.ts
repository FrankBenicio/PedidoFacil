export enum PedidoStatus {
  Pendente = 1,
  Pago = 2,
  Cancelado = 3
}

export interface PedidoItemResponse {
  ProdutoId: string;
  ProdutoNome: string;
  Quantidade: number;
  ValorUnitario: number;
  ValorTotal: number;
}

export interface PedidoResponse {
  Id: string;
  Status: PedidoStatus;
  ValorTotal: number;
  CreatedAt: string;
  Itens: PedidoItemResponse[];
}

export interface CreatePedidoItemRequest {
  ProdutoId: string;
  Quantidade: number;
}

export interface CreatePedidoRequest {
  Itens: CreatePedidoItemRequest[];
}

export interface UpdatePedidoStatusRequest {
  Status: PedidoStatus;
}
