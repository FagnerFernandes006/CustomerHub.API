# CustomerHub API

API REST desenvolvida em ASP.NET Core com foco em aplicação dos conceitos de **Domain Driven Design (DDD)**.

O objetivo do projeto foi construir um CRUD de clientes com separação de responsabilidades entre camadas, regras de domínio centralizadas e arquitetura preparada para evolução.

---

## Arquitetura

O projeto foi organizado seguindo o padrão DDD em camadas:

```plaintext
CustomerHub

API
│
├── Controllers
│
Application
│
├── DTOs
├── Services
│
Domain
│
├── Entities
├── Interfaces
├── Exceptions
│
Infrastructure
│
├── Context
├── Repositories
```

### Responsabilidade de cada camada

### API

Responsável pela exposição dos endpoints HTTP e configuração da aplicação.

### Application

Contém serviços da aplicação, DTOs e orquestração dos casos de uso.

### Domain

Camada principal contendo:

* Entidades
* Regras de negócio
* Exceções de domínio
* Contratos (interfaces)

### Infrastructure

Implementações técnicas:

* Entity Framework Core
* Repositórios
* Persistência de dados

---

## Tecnologias utilizadas

* ASP.NET Core Web API
* .NET
* Entity Framework Core
* SQL Server
* Swagger / OpenAPI
* Domain Driven Design (DDD)

---

## Funcionalidades

### Clientes

* Criar cliente
* Buscar cliente por ID
* Listar clientes com paginação
* Atualizar cliente
* Remover cliente
* Validação de email
* Tratamento global de exceções

---

## Regras implementadas

### Domínio

* Nome obrigatório
* Email obrigatório
* Email deve possuir formato válido
* Entidade encapsula alterações através de métodos próprios

Exemplo:

```csharp
customer.ChangeName(...)
customer.ChangeEmail(...)
customer.Update(...)
```

---

## Endpoints

### Criar cliente

```http
POST /api/customers
```

Request:

```json
{
  "name": "Fagner",
  "email": "fagner@email.com"
}
```

Response:

```json
{
  "id": "guid",
  "name": "Fagner",
  "email": "fagner@email.com"
}
```

---

### Listar clientes (paginado)

```http
GET /api/customers?page=1&pageSize=10
```

Response:

```json
{
  "page": 1,
  "pageSize": 10,
  "totalItems": 20,
  "totalPages": 2,
  "data": []
}
```

---

## Como executar

### 1. Clonar repositório

```bash
git clone <url-do-repositorio>
```

### 2. Configurar Connection String

Editar:

```plaintext
appsettings.json
```

Exemplo:

```json
"ConnectionStrings": {
 "Default": "Server=localhost;Database=CustomerHubDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

### 3. Aplicar migrations

Executar:

```powershell
Update-Database
```

### 4. Executar aplicação

Iniciar o projeto:

```plaintext
CustomerHub.API
```

Abrir:

```plaintext
/swagger
```

---

## Conceitos aplicados

* Domain Driven Design (DDD)
* Repository Pattern
* Dependency Injection
* Encapsulamento
* Separação de responsabilidades
* Exception Middleware
* Paginação
* API REST

---

## Melhorias futuras

* Autenticação JWT
* Testes unitários
* FluentValidation
* Value Objects
* Docker
* Logs estruturados
* CI/CD

---

Projeto desenvolvido para estudo e evolução em arquitetura e desenvolvimento back-end com .NET.
