import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { PedidoService } from '../../core/services/pedido.service';
import { PedidoResponse, PedidoStatus } from '../../core/models/pedido.model';

@Component({
  selector: 'app-pedido-detalhe',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './pedido-detalhe.component.html'
})
export class PedidoDetalheComponent implements OnInit {
  pedido?: PedidoResponse;
  loading = false;
  error = '';

  constructor(
    private readonly route: ActivatedRoute,
    private readonly pedidoService: PedidoService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (!id) return;

    this.loading = true;
    this.pedidoService.obterPorId(id).subscribe({
      next: pedido => { this.pedido = pedido; this.loading = false; },
      error: err => { this.error = err.message; this.loading = false; }
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
}
