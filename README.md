# dotnet-ambev-api

Este repositório contém um projeto de Web API Restful desenvolvida com o framework ASP .NET e está estruturado em camadas com uma arquitetura Clean, onde é feito o uso de Padrões como Mediator e CRQS para separar as responsabilidades e reduzir o acoplamento entre as classes.

Em cima da estrutura que já existia foi feito uma modelagem de um sistema de registro de vendas usando DDD e foi criado o recurso **orders** para ser exposto pela API para fazer o cadastro, atualização, exclusão e recuperação de pedidos.

As seguintes entidades foram modeladas:

- Order
- OrderItem
- Customer
- Product
- Branch

Os seguintes serviços foram adicionados:

- ServiceBase
- OrderService

Os seguintes repositórios foram adicionados:

- RepositoryBase
- OrderItemRepository
- CustomerRepository

  Os seguintes handlers foram adicionados:

  - CreateOrderHandler
  - UpdateOrderHandler
  - GetOrdersHandler
  - GetOrderByIdHandler
  

## Pré-requisitos:

Antes de executar o projeto certifique-se de ter as configurações abaixo instaladas no seu ambiente.

+ .NET SDK 8 ou superior
+ Visual Studio 2022
+ PostgreSQL rodando localmente no seu ambiente
+ GIT

## Rodando o projeto:

Siga os passos abaixo para rodar o projeto.

1. Abra o terminal do sistema operacional e clone este repositório utilizando o GIT com o comando **git clone** https://github.com/lpjfalcao/dotnet-ambev-api.git 
2. Abra a solução no Visual Studio 
3. Abra o arquivo appsettings.json do projeto clonado e configure o seu usuário e senha do PostgreSQL na string de conexão.
4. Vá até o console do gerenciador de pacotes do nuget
5. Selecione o projeto Ambev.DeveloperEvaluation.ORM
6. Rode o comando **Update-Database**
7. Ao final você deve ter um banco de dados configurado na sua instância do PostgreSQL em sua máquina com as tabelas usadas no projeto


## Testando o Projeto

Você pode utilizar a interface do Swagger para testar alguns endpoints: https://localhost:7181/swagger/index.html

1. **Listagem de Pedidos** - endpoint: GET /api/orders
2. **Listagem de um Pedido específico** - endpoint: GET /api/orders/{id}
3. **Criação de Pedidos** - endpoint: POST /api/orders
4. **Atualização de Pedidos** - endpoint: POST /api/orders/{id}/
5. **Remoção de Pedidos** - endpoint: DELETE /api/orders/{id}/

Obs.: 
Existem outros endpoints além dos citados acima que você pode explorar na interface do Swagger, mas eles já existiam no projeto e não implementei eles.

