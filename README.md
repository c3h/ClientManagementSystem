# **Client Management System**

## **Pré-requisitos**

- **.NET SDK 8.0**
- **Node.js** (versão 16 ou superior)
- **npm** (geralmente vem com o Node.js)
- **Docker** e **Docker Compose**
- **Git**

---

## **Estrutura do Projeto**

```
ClientManagementSystem/
├── backend/
│   └── CustomerManagementApi/
├── frontend/
│   └── customer-management-app/
└── README.md
```

- **backend/**: Contém o projeto back-end em .NET 8.
- **frontend/**: Contém o projeto front-end em Next.js.

---

## **Configuração Inicial**

### **1. Clonar o Repositório**

```bash
git clone https://github.com/seu-usuario/ClientManagementSystem.git
cd ClientManagementSystem
```

---

## **Instruções para Executar o Back-end**

```
ClientManagementSystem/
└── backend/
    └── CustomerManagementApi/
```

### **1. Iniciar o Banco de Dados com Docker**

Na raiz do projeto, execute:

```bash
docker-compose up -d
```

### **2. Aplicar as Migrações do Entity Framework**

```bash
dotnet restore
dotnet ef database update
```

### **3. Executar a API**

Inicie a aplicação:

```bash
dotnet run
```

A API estará disponível em `http://localhost:5025`.

### **4. Testar a API com o Swagger**

Via `http://localhost:5025/swagger`.

---

## **Instruções para Executar o Front-end**

```
ClientManagementSystem/
└── frontend/
    └── customer-management-app/
```

### **1. Instalar Dependências**

Na raiz do projeto execute:

```bash
npm install
```

### **2. Executar o Projeto**

Inicie a aplicação:

```bash
npm run dev
```

O front-end estará disponível em `http://localhost:3000`.

## **Scripts do Banco de Dados**

Os scripts SQL para criação das tabelas estão implementados nas migrações do Entity Framework, mas segue a baixo um exemplo:

```sql
CREATE TABLE CustomerType (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Description VARCHAR(50) NOT NULL
);

CREATE TABLE CustomerStatus (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Description VARCHAR(50) NOT NULL
);

CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    CPF CHAR(11) NOT NULL UNIQUE,
    CustomerTypeId INT NOT NULL,
    Gender CHAR(1) NOT NULL,
    CustomerStatusId INT NOT NULL,
    CONSTRAINT FK_Customers_CustomerType FOREIGN KEY (CustomerTypeId) REFERENCES CustomerType(Id),
    CONSTRAINT FK_Customers_CustomerStatus FOREIGN KEY (CustomerStatusId) REFERENCES CustomerStatus(Id),
    CONSTRAINT CK_Customers_Gender CHECK (Gender IN ('M', 'F'))
);
```

---

## **Tecnologias Utilizadas**

- **Back-end:**

  - C# (.NET 8)
  - ASP.NET Core Web API
  - Entity Framework Core
  - AutoMapper
  - Swagger para documentação
  - Docker e Docker Compose

- **Front-end:**
  - Next.js (React)
  - TypeScript
  - shadcn/ui
  - Axios para requisições HTTP
  - Tailwind CSS (utilizado pelo shadcn/ui)

---
