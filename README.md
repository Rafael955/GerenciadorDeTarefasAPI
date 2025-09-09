# Gerenciador de Tarefas

Este projeto é uma API para gerenciamento de tarefas, desenvolvida em .NET 9, utilizando arquitetura em camadas (Domain, Infra, API) e princípios SOLID. O objetivo é fornecer endpoints para criar, listar, atualizar, excluir e consultar tarefas, com regras de negócio bem definidas e persistência em banco de dados SQL Server.

---

## Sumário

- [Pré-requisitos](#pré-requisitos)
- [Configuração do Projeto Localmente](#configuração-do-projeto-localmente)
- [Rodando a Aplicação](#rodando-a-aplicação)
- [Rodando os Testes](#rodando-os-testes)
- [Banco de Dados](#banco-de-dados)
- [Estrutura do Projeto](#estrutura-do-projeto)

---

## Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server LocalDB](https://docs.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb)
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/)

---

## Configuração do Projeto Localmente

1. **Clone o repositório:**

git clone <url-do-repositorio> cd GerenciadorDeTarefas

2. **Restaure os pacotes NuGet:**

dotnet restore

3. **Configure a string de conexão do banco de dados:**
- No arquivo `GerenciadorDeTarefas.Api/appsettings.json`, ajuste a string de conexão conforme seu ambiente:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=BDGerenciadorDeTarefas;Trusted_Connection=True;"
  }
  ```

4. **Aplique as migrações para criar o banco de dados:**

dotnet ef database update --project GerenciadorDeTarefas.Infra.Data --startup-project GerenciadorDeTarefas.Api

---

## Rodando a Aplicação

1. **Execute a API:**

dotnet test

---

## Banco de Dados

- **Tipo:** SQL Server (LocalDB)
- **Nome:** BDGerenciadorDeTarefas
- **Script de criação:** Veja o script abaixo ou utilize as migrações do Entity Framework.
- **Tabela principal:** `TAREFA`

Script da tabela de tarefas:
 
CREATE TABLE [dbo].[TAREFA] ( [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [Titulo] NVARCHAR(100) NOT NULL, [Descricao] NVARCHAR(MAX) NULL, [DataCriacao] DATETIME2 NOT NULL, [DataConclusao] DATETIME2 NULL, [Status] INT NOT NULL )

---

## Estrutura do Projeto

- **GerenciadorDeTarefas.Domain**: Entidades, DTOs, Validadores, Mapeadores, Interfaces e Regras de Negócio.
- **GerenciadorDeTarefas.Infra.Data**: Contexto do EF Core, Mapeamentos, Repositórios e Migrations.
- **GerenciadorDeTarefas.Api**: Controllers, Configurações e inicialização da aplicação.

---
