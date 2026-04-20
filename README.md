<div align="center">
  <h1>🚀 TareFacil API</h1>
  <p>Uma poderosa API focada no gerenciamento ágil de tarefas construída com .NET 10 e Clean Architecture.</p>
</div>

---

## 📌 Sobre o Projeto

O **TareFacil** é uma API RESTful para gestão de tarefas, construída com foco em boas práticas de engenharia de software e manutenibilidade. O projeto utiliza o padrão de **Clean Architecture** (Arquitetura Limpa), visando o completo isolamento das regras de negócio do banco de dados e da interface da API, permitindo escala e facilidade nos testes.

## 🛠️ Tecnologias Utilizadas

Este projeto foi desenvolvido com as mais recentes e modernas tecnologias do ecossistema .NET:

- **[.NET 10](https://dotnet.microsoft.com/)**: Plataforma de desenvolvimento principal.
- **[C# 13](https://docs.microsoft.com/pt-br/dotnet/csharp/)**: Linguagem de programação moderna, orientada a objetos e fortemente tipada.
- **[Entity Framework Core 9](https://docs.microsoft.com/pt-br/ef/core/)**: ORM (*Object-Relational Mapper*) para facilitar as interações com o banco de dados.
- **[MySQL (Pomelo EF Core)](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)**: Banco de Dados Relacional principal.
- **[Docker / Docker Compose](https://www.docker.com/)**: Containerização, facilitando a execução do banco de dados na máquina de desenvolvimento.
- **[Swagger / OpenAPI](https://swagger.io/)**: Para mapeamento e testes via interface gráfica convencional.
- **[Scalar](https://github.com/scalar/scalar)**: Interface alternativa e moderna para a documentação da API baseada no OpenAPI.

## 🏗️ Arquitetura do Projeto

A solução foi estruturada baseada no conceito de **Clean Architecture** e dividida em quatro camadas (projetos) principais, para garantir separação de responsabilidades (SoC) e princípios SOLID:

- **`TareFacil.API` (Camada de Apresentação)**: Contém os *Controllers*, configurações de injeção de dependência (`Program.cs`), Middleware (como CORS e Swagger) e é a porta de entrada para o sistema.
- **`TareFacil.Application` (Camada de Aplicação)**: Responsável pelas regras de coordenação, casos de uso e Serviços da aplicação. É a ponte entre as interações externas (API) e as regras do domínio.
- **`TareFacil.Domain` (Camada de Domínio)**: É o coração do software. Aqui estão contidas as *Entities* (Entidades), regras estritas de negócios e *Interfaces* abstratas (ex: `IBaseRepository`). Ela é completamente isolada, não possuindo dependência de outras camadas.
- **`TareFacil.Infra.Data` (Camada de Infraestrutura de Dados)**: Realiza a persistência real dos dados. Implementa ativamente as interfaces definidas no Domínio e contém todo o contexto do Entity Framework (`DataContext`), bem como os Repositórios (`TarefaRepository`).

## ⚙️ Pré-requisitos

Para rodar este projeto na sua máquina de desenvolvimento de forma ideal, você precisará ter:

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) ou superior.
- [Docker e Docker Compose](https://www.docker.com/products/docker-desktop) instalado para o banco de dados (ou uma instância do MySQL v8.0 instalada e rodando localmente na porta 3306/3307).
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/) ou [Visual Studio Code](https://code.visualstudio.com/).

## 🚀 Como Executar o Projeto

Siga o passo a passo para baixar e testar a aplicação em seu ambiente:

### 1. Clonando o Repositório
```bash
git clone https://github.com/seu-usuario/TareFacil.git
cd TareFacil
```

### 2. Subindo a infraestrutura (MySQL via Docker)
O projeto conta com um arquivo `docker-compose.yml` pré-configurado na raiz para disponibilizar o MySQL no seu ambiente local (exposto na porta `3307`).

Na raiz do projeto, execute:
```bash
docker-compose up -d
```
*(As credenciais configuradas para teste encontram-se dentro do próprio `docker-compose.yml`, como user `admin` e banco `BDTareFacil`)*

### 3. Configurando a Connection String (Opcional)
Se você optar por subir de outra forma (sem o docker-compose), será necessário atualizar a string de conexão no arquivo `appsettings.Development.json` e `appsettings.json` na pasta do projeto `TareFacil.API`.

### 4. Aplicando Migrations
Vá até o diretório da API (ou defina o projeto inicial via Visual Studio/CLI) para aplicar a migração inicial do EF Core e criar seu banco:

```bash
cd TareFacil.API
dotnet ef database update --project ../TareFacil.Infra.Data
```

### 5. Executando a API API
Para levantar o servidor e interagir com toda a aplicação:
```bash
dotnet run --project TareFacil.API
```
A API será executada e deve estar disponível em `localhost`. 

### 6. Acessando a Documentação
Assim que iniciado os endpoints documentados estarão em:
- **Swagger UI**: `http://localhost:<porta>/swagger`
- **Scalar UI**: `http://localhost:<porta>/scalar` _(Uma visão maravilhosa para devs focada em design moderno de documentação)_

---

## 🔒 Segurança & Acesso

CORS: O projeto já está configurado para uma política de CORS específica chamada `"AngularApp"` em sua inicialização, lendo os origens confiáveis a partir do `appsettings.json`, focado em integrar fluentemente num front-end externo localmente.
