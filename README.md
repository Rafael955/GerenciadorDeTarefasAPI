# Gerenciador de Tarefas

Este projeto � uma API para gerenciamento de tarefas, desenvolvida em .NET 9, utilizando arquitetura em camadas (Domain, Infra, API) e princ�pios SOLID. O objetivo � fornecer endpoints para criar, listar, atualizar, excluir e consultar tarefas, com regras de neg�cio bem definidas e persist�ncia em banco de dados SQL Server.

---

## Sum�rio

- [Pr�-requisitos](#pr�-requisitos)
- [Configura��o do Projeto Localmente](#configura��o-do-projeto-localmente)
- [Rodando a Aplica��o](#rodando-a-aplica��o)
- [Rodando os Testes](#rodando-os-testes)
- [Banco de Dados](#banco-de-dados)
- [Estrutura do Projeto](#estrutura-do-projeto)

---

## Pr�-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server LocalDB](https://docs.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb)
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/)

---

## Configura��o do Projeto Localmente

1. **Clone o reposit�rio:**

git clone <url-do-repositorio> cd GerenciadorDeTarefas

2. **Restaure os pacotes NuGet:**

dotnet restore

3. **Configure a string de conex�o do banco de dados:**
- No arquivo `GerenciadorDeTarefas.Api/appsettings.json`, ajuste a string de conex�o conforme seu ambiente:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=BDGerenciadorDeTarefas;Trusted_Connection=True;"
  }
  ```

4. **Aplique as migra��es para criar o banco de dados:**

dotnet ef database update --project GerenciadorDeTarefas.Infra.Data --startup-project GerenciadorDeTarefas.Api

---

## Rodando a Aplica��o

1. **Execute a API:**

dotnet test

---

## Banco de Dados

- **Tipo:** SQL Server (LocalDB)
- **Nome:** BDGerenciadorDeTarefas
- **Script de cria��o:** Veja o script abaixo ou utilize as migra��es do Entity Framework.
- **Tabela principal:** `TAREFA`

Script da tabela de tarefas:
 
CREATE TABLE [dbo].[TAREFA] ( [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [Titulo] NVARCHAR(100) NOT NULL, [Descricao] NVARCHAR(MAX) NULL, [DataCriacao] DATETIME2 NOT NULL, [DataConclusao] DATETIME2 NULL, [Status] INT NOT NULL )

---

## Estrutura do Projeto

- **GerenciadorDeTarefas.Domain**: Entidades, DTOs, Validadores, Mapeadores, Interfaces e Regras de Neg�cio.
- **GerenciadorDeTarefas.Infra.Data**: Contexto do EF Core, Mapeamentos, Reposit�rios e Migrations.
- **GerenciadorDeTarefas.Api**: Controllers, Configura��es e inicializa��o da aplica��o.

---
