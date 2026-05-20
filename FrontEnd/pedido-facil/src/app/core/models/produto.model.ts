export interface ProdutoResponse {
  Id: string;
  Nome: string;
  Preco: number;
  Estoque: number;
}

export interface CreateProdutoRequest {
  Nome: string;
  Preco: number;
  Estoque: number;
}

export interface UpdateProdutoRequest extends CreateProdutoRequest {}
