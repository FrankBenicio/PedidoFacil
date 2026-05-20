import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProdutoService } from '../../core/services/produto.service';
import { ProdutoResponse } from '../../core/models/produto.model';

@Component({
  selector: 'app-produtos',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './produtos.component.html'
})
export class ProdutosComponent implements OnInit {
  produtos: ProdutoResponse[] = [];
  loading = false;
  error = '';
  success = '';

  form = { Id: '', Nome: '', Preco: 0, Estoque: 0 };

  constructor(private readonly produtoService: ProdutoService) {}

  ngOnInit(): void {
    this.carregar();
  }

  carregar(): void {
    this.loading = true;
    this.error = '';
    this.produtoService.listar().subscribe({
      next: produtos => { this.produtos = produtos; this.loading = false; },
      error: err => { this.error = err.message; this.loading = false; }
    });
  }

  salvar(): void {
    this.error = '';
    this.success = '';

    const request = {
      Nome: this.form.Nome,
      Preco: Number(this.form.Preco),
      Estoque: Number(this.form.Estoque)
    };

    const observable = this.form.Id
      ? this.produtoService.atualizar(this.form.Id, request)
      : this.produtoService.criar(request);

    observable.subscribe({
      next: response => {
        this.success = response.Message || 'Operação realizada com sucesso.';
        this.limpar();
        this.carregar();
      },
      error: err => this.error = err.message
    });
  }

  editar(produto: ProdutoResponse): void {
    this.form = { ...produto };
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }

  remover(id: string): void {
    if (!confirm('Deseja remover este produto?')) return;

    this.produtoService.remover(id).subscribe({
      next: response => {
        this.success = response.Message || 'Produto removido.';
        this.carregar();
      },
      error: err => this.error = err.message
    });
  }

  limpar(): void {
    this.form = { Id: '', Nome: '', Preco: 0, Estoque: 0 };
  }
}
