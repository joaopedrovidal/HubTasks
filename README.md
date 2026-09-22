# #📜 HubTasks API

API REST desenvolvida em **C# com ASP.NET Core** para gerenciamento de tarefas.

O projeto permite realizar operações de cadastro, consulta, edição e exclusão de tarefas (CRUD).

## 🚀 Tecnologias utilizadas

- C#
- .NET
- ASP.NET Core Web API
- Swagger
- HTTP/REST

## 📋 Funcionalidades

A API possui as seguintes operações:

- Criar um tarefa;
- Listar todas as tarefas;
- Buscar uma tarefa pelo ID;
- Editar uma tarefa;
- Excluir uma tarefa.

Cada tarefa possui:

- ID único gerado automaticamente com `Guid`;
- Nome;
- Descricao;
- Data de Conclusão;
- Status;
- Prioridade;

## ⚙️ Pré-requisitos

Para executar o projeto, é necessário ter instalado:

- [.NET SDK](https://dotnet.microsoft.com/download)

Para verificar se o .NET está instalado:

```bash
dotnet --version
