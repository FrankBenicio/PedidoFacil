import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  template: `
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark shadow-sm">
      <div class="container">
        <a class="navbar-brand fw-bold" routerLink="/pedidos">
          <i class="bi bi-bag-check me-2"></i>Pedido Fácil
        </a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#menu">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="menu">
          <ul class="navbar-nav ms-auto">
            <li class="nav-item">
              <a class="nav-link" routerLink="/pedidos" routerLinkActive="active">Pedidos</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" routerLink="/produtos" routerLinkActive="active">Produtos</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  `
})
export class NavbarComponent {}
