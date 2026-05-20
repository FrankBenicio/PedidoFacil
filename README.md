# Pedido Fácil API

API REST para cadastro e acompanhamento de pedidos, desenvolvida em .NET Framework 4.7.2 com Web API 2, Entity Framework 6 e SQL Server.

## Tecnologias

- .NET Framework 4.7.2
- ASP.NET Web API 2
- Entity Framework 6
- SQL Server
- FluentValidation
- Unity Dependency Injection
- Swagger

## Arquitetura

O projeto foi organizado em camadas, seguindo uma abordagem inspirada em Clean Architecture:

```txt
src
├── PedidoFacil.API
├── PedidoFacil.Application
├── PedidoFacil.Domain
└── PedidoFacil.Infrastructure
```

## Funcionalidades

- Cadastro de produtos
- Cadastro de pedidos
- Controle de estoque
- Atualização de status
- Swagger
- FluentValidation
- SQL Server

## Como executar

### Pré-requisitos

- Visual Studio 2022
- .NET Framework 4.7.2
- SQL Server

### Configurar banco

No arquivo Web.config:

```xml
<connectionStrings>
  <add
    name="PedidoFacilConnection"
    connectionString="Server=localhost;Database=PedidosDb;Trusted_Connection=True;"
    providerName="System.Data.SqlClient" />
</connectionStrings>
```

### Executar migrations

```powershell
Update-Database
```

### Executar projeto

Defina o projeto `PedidoFacil.API` como startup e execute com F5.

Swagger:

```txt
https://localhost:44338/swagger
```

## Endpoints

### Produtos

```http
GET /api/produtos
POST /api/produtos
PUT /api/produtos/{id}
DELETE /api/produtos/{id}
```

### Pedidos

```http
GET /api/pedidos
POST /api/pedidos
PATCH /api/pedidos/{id}/status
```

## Decisões técnicas

- Arquitetura em camadas
- UseCases
- Repository Pattern
- Factory Method
- Rich Domain Model
- FluentValidation
