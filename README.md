## Requisitos

### NET 9.0
https://dotnet.microsoft.com/pt-br/download/dotnet/9.0


### Global.json atual
```json
{
  "projects": ["src"],
  "sdk": { "version": "9.0.300" }
}
```

# Começando

Este guia fornece instruções passo a passo para configurar e executar o projeto localmente.

Verifique as instalações:
```sh
dotnet --version
git --version
```

### Passo 1: Clone o repositório
Clone the project from GitHub:
```bash
git clone https://github.com/mvtorrecilha/acompanhamento-basquete.git
cd acompanhamento-basquete
```

### Passo 2: Criar o banco de dados no Sql Server

Este projeto utiliza Entity Framework Core Migrations para gerenciar alterações no esquema do banco de dados ao longo do tempo.

Entre no diretório `src` e execute o comando abaixo:

```bash
dotnet ef database update --project ./src/AcompanhamentoBasquete.Infra.Data.SQL --startup-project ./src/AcompanhamentoBasquete.API
```

### Passo 3: Iniciar os Serviços

Restaure as dependências:
```bash
dotnet restore
```

Rode a aplicação:
```bash
dotnet run
```

A API roda em HTTPS (7265) por padrão, mas HTTP (5195) também está disponível.
