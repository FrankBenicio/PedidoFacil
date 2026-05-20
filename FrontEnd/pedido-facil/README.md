# Pedido Fácil - Frontend Angular

Frontend em Angular standalone consumindo a API `PedidoFacil.API` em .NET Framework 4.8.

## Stack

- Angular mais recente
- Bootstrap 5
- Bootstrap Icons
- HttpClient
- Standalone Components

## Rotas consumidas

### Produtos

- `GET /api/produtos`
- `GET /api/produtos/{id}`
- `POST /api/produtos`
- `PUT /api/produtos/{id}`
- `DELETE /api/produtos/{id}`

### Pedidos

- `GET /api/pedidos`
- `GET /api/pedidos?status=1`
- `GET /api/pedidos/{id}`
- `POST /api/pedidos`
- `PATCH /api/pedidos/{id}/status`

## Configurar URL da API

Abra:

```txt
src/app/core/services/environment.ts
```

Altere a URL se sua API estiver em outra porta:

```ts
export const environment = {
  apiUrl: 'https://localhost:44338/api'
};
```

## Rodar

```bash
npm install
npm start
```

## Atenção ao CORS

Se o Angular não conseguir chamar a API, habilite CORS no projeto Web API 2.

Instale na API:

```powershell
Install-Package Microsoft.AspNet.WebApi.Cors
```

No `WebApiConfig.cs`:

```csharp
using System.Web.Http.Cors;

public static void Register(HttpConfiguration config)
{
    var cors = new EnableCorsAttribute("*", "*", "*");
    config.EnableCors(cors);

    config.MapHttpAttributeRoutes();
}
```

## Telas

- `/pedidos`: lista pedidos, filtra por status, cria pedido, paga e cancela
- `/pedidos/:id`: detalhe do pedido
- `/produtos`: CRUD de produtos
