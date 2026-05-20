using PedidoFacil.Application.Interfaces.Repositories;
using PedidoFacil.Application.Interfaces.UseCases;
using PedidoFacil.Application.UseCases.Pedidos;
using PedidoFacil.Application.UseCases.Produtos;
using PedidoFacil.Infrastructure.Persistence;
using PedidoFacil.Infrastructure.Repositories;
using PedidosApi.Application.Interfaces.UseCases;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace PedidoFacil.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // DbContext
            container.RegisterType<AppDbContext>(
                new HierarchicalLifetimeManager());

            // Repositories
            container.RegisterType<IProdutoRepository, ProdutoRepository>();
            container.RegisterType<IPedidoRepository, PedidoRepository>();

            // UseCases
            container.RegisterType<IListarPedidosUseCase, ListarPedidosUseCase>();
            container.RegisterType<IObterPedidoPorIdUseCase, ObterPedidoPorIdUseCase>();
            container.RegisterType<ICriarPedidoUseCase, CriarPedidoUseCase>();
            container.RegisterType<IAtualizarStatusPedidoUseCase, AtualizarStatusPedidoUseCase>();
            container.RegisterType<IListarProdutosUseCase, ListarProdutosUseCase>();
            container.RegisterType<IObterProdutoPorIdUseCase, ObterProdutoPorIdUseCase>();
            container.RegisterType<ICriarProdutoUseCase, CriarProdutoUseCase>();
            container.RegisterType<IAtualizarProdutoUseCase, AtualizarProdutoUseCase>();
            container.RegisterType<IDeletarProdutoUseCase, DeletarProdutoUseCase>();

            GlobalConfiguration.Configuration.DependencyResolver =
                new UnityDependencyResolver(container);
        }
    }
}