import { Routes } from '@angular/router';
import { ProdutosComponent } from './pages/produtos/produtos.component';
import { PedidosComponent } from './pages/pedidos/pedidos.component';
import { PedidoDetalheComponent } from './pages/pedido-detalhe/pedido-detalhe.component';

export const routes: Routes = [
  { path: '', redirectTo: 'pedidos', pathMatch: 'full' },
  { path: 'produtos', component: ProdutosComponent },
  { path: 'pedidos', component: PedidosComponent },
  { path: 'pedidos/:id', component: PedidoDetalheComponent },
  { path: '**', redirectTo: 'pedidos' }
];
