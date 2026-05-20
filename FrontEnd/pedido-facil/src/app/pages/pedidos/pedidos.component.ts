import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { PedidoService } from '../../core/services/pedido.service';
import { ProdutoService } from '../../core/services/produto.service';
import { PedidoResponse, PedidoStatus } from '../../core/models/pedido.model';
import { ProdutoResponse } from '../../core/models/produto.model';

@Component({
  selector: 'app-pedidos',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './pedidos.component.html'
})
export class PedidosComponent implements OnInit {
  pedidos: PedidoResponse[] = [];
  produtos: ProdutoResponse[] = [];
  loading = false;
  error = '';
  success = '';
  statusFiltro: PedidoStatus | null = null;
  pedidoStatus = PedidoStatus;

  novoPedido = {
    ProdutoId: '',
    Quantidade: 1
  };

  constructor(
    private readonly pedidoService: PedidoService,
    private readonly produtoService: ProdutoService
  ) {}

  ngOnInit(): void {
    this.carregarProdutos();
    this.carregarPedidos();
  }

  carregarProdutos(): void {
    this.produtoService.listar().subscribe({
      next: produtos => this.produtos = produtos,
      error: err => this.error = err.message
    });
  }

  carregarPedidos(): void {
    this.loading = true;
    this.error = '';
    this.pedidoService.listar(this.statusFiltro).subscribe({
      next: pedidos => { this.pedidos = pedidos; this.loading = false; },
      error: err => { this.error = err.message; this.loading = false; }
    });
  }

  criarPedido(): void {
    this.error = '';
    this.success = '';

    this.pedidoService.criar({
      Itens: [{
        ProdutoId: this.novoPedido.ProdutoId,
        Quantidade: Number(this.novoPedido.Quantidade)
      }]
    }).subscribe({
      next: response => {
        this.success = response.Message || 'Pedido criado com sucesso.';
        this.novoPedido = { ProdutoId: '', Quantidade: 1 };
        this.carregarProdutos();
        this.carregarPedidos();
      },
      error: err => this.error = err.message
    });
  }

  alterarStatus(id: string, status: PedidoStatus): void {
    this.pedidoService.atualizarStatus(id, { Status: status }).subscribe({
      next: response => {
        this.success = response.Message || 'Status atualizado.';
        this.carregarPedidos();
      },
      error: err => this.error = err.message
    });
  }

  statusTexto(status: PedidoStatus): string {
    switch (status) {
      case PedidoStatus.Pendente: return 'Pendente';
      case PedidoStatus.Pago: return 'Pago';
      case PedidoStatus.Cancelado: return 'Cancelado';
      default: return 'Desconhecido';
    }
  }

  statusClasse(status: PedidoStatus): string {
    switch (status) {
      case PedidoStatus.Pendente: return 'bg-warning text-dark';
      case PedidoStatus.Pago: return 'bg-success';
      case PedidoStatus.Cancelado: return 'bg-danger';
      default: return 'bg-secondary';
    }
  }
}
