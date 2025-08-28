## Acompanhamento de pontos de jogos de basquete.

Esta aplicação foi desenvolvida para registrar e acompanhar estatísticas de pontuação em partidas de basquete ao longo de uma temporada.


# Começando

Este guia fornece instruções passo a passo para configurar e executar o projeto localmente.

## Backend

## Pré-requisitos

### NET 9.0
https://dotnet.microsoft.com/pt-br/download/dotnet/9.0


### Global.json atual
```json
{
  "projects": ["src"],
  "sdk": { "version": "9.0.300" }
}
```

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


## Front-End

## Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- **Node.js** (versão recomendada >= 20.x)
- **Angular CLI** versão compatível com Angular 19


### Passo 1: Instalação das dependências

```bash
npm install
```

### Passo 2: Iniciar a aplicação web:

```bash
ng serve
```

Por padrão, o Angular rodará em:
http://localhost:4200


# Imagens da aplicação

### Lançar pontos
![Lançar Pontos](docs/screenshots/lançar_pontos.png)

### Resultados
![Resultados](docs/screenshots/resultados_pontos.png)