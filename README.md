# SmartCollect 🚀

Plataforma de Gestão de Cobrança Multicanal  
Residência de Software 2026.1 — Atos Capital

---

## Pré-requisitos

Antes de clonar o projeto, instale na sua máquina:

| Ferramenta | Download | Obs |
|---|---|---|
| Docker Desktop | [docker.com/products/docker-desktop](https://www.docker.com/products/docker-desktop) | Necessário WSL2 no Windows |
| .NET 10 SDK | [dot.net/download](https://dotnet.microsoft.com/download) | Versão x64 |
| Git | [git-scm.com](https://git-scm.com) | |

---

## Como rodar o projeto

### 1. Clone o repositório

```bash
git clone https://github.com/davisantbjj/SmartCollect.git
cd SmartCollect
```

### 2. Crie o arquivo `.env`

Use o template já versionado e depois preencha os valores:

```bash
copy .env.example .env
```

No PowerShell, `copy` e `cp` funcionam como alias.

Conteúdo mínimo recomendado para rodar local:

```env
POSTGRES_USER=""
POSTGRES_PASSWORD=""
POSTGRES_DB=""
PGADMIN_EMAIL=""
PGADMIN_PASSWORD=""
```

> ⚠️ **NUNCA commite o `.env`!** Ele já está no `.gitignore`.

> ✅ A API também lê o `.env` automaticamente em desenvolvimento.
> Para conexão com banco, use preferencialmente: `POSTGRES_HOST`, `POSTGRES_PORT`, `POSTGRES_DB`, `POSTGRES_USER`, `POSTGRES_PASSWORD`.
> Se quiser sobrescrever só para a API local, também pode usar: `DB_HOST`, `DB_PORT`, `DB_NAME`, `DB_USER`, `DB_PASSWORD`.

### 3. Suba o banco de dados

Com o Docker Desktop **aberto e rodando**, execute na raiz do projeto:

```bash
docker compose up -d
```

Saída esperada:
```
✔ Container smartcollect_db      Started
✔ Container smartcollect_pgadmin Started
```

Verifique se os serviços ficaram saudáveis:

```bash
docker compose ps
```

### 4. Instale o dotnet-ef (apenas uma vez por máquina)

```bash
dotnet tool install --global dotnet-ef --version 10.0.0
```

### 5. Aplique as migrations (cria as tabelas no banco)

```bash
cd src/SmartCollect.Api
dotnet ef database update
```

### 6. Rode a API

```bash
dotnet run
```

Se o banco estiver no Docker com o `.env` configurado, a API usará essas variáveis para montar a conexão.

Portas padrão do ambiente:
- PostgreSQL externo: `localhost:55432`
- pgAdmin: `localhost:8080`
- API: `localhost:5013`

Acesse o Swagger em: **http://localhost:5013/swagger**

---

## Verificar se tudo está funcionando

| Serviço | URL | Credenciais |
|---|---|---|
| API (Swagger) | http://localhost:5013/swagger | — |
| PostgreSQL | localhost:55432 | definidas no `.env` |
| pgAdmin (banco) | http://localhost:8080 | definidas no `.env` |

No pgAdmin, registre o servidor com:
- Host: `postgres`
- Port: `5432`
- Username/Password: os mesmos do `.env`

---

## Estrutura do Projeto

```
SmartCollect/
├── docker-compose.yml       ← PostgreSQL + pgAdmin
├── .env                     ← Senhas (não commitar!)
├── .gitignore
├── README.md
├── src/
│   └── SmartCollect.Api/    ← Projeto ASP.NET Core
│       ├── Controllers/     ← Endpoints HTTP
│       ├── Models/          ← Entidades do banco
│       ├── Services/        ← Regras de negócio
│       ├── DTOs/            ← Objetos de entrada/saída
│       ├── Settings/        ← Configurações da API
│       ├── Data/
│       │   └── Repositories/
│       │       └── AppDbContext.cs
│       ├── Migrations/      ← Geradas pelo EF Core
│       ├── Program.cs
│       └── appsettings.json
└── tests/                   ← Testes automatizados (xUnit)
```

---

## Comandos úteis do dia a dia

```bash
# Subir o banco
docker compose up -d

# Ver status dos serviços
docker compose ps

# Parar o banco
docker compose down

# Nova migration (após alterar um Model)
dotnet ef migrations add NomeDaMigration

# Aplicar migrations no banco
dotnet ef database update

# Rodar a API
dotnet run

# Compilar sem rodar
dotnet build
```

---

## Stack tecnológico

- **Backend:** ASP.NET Core 10 / C#
- **ORM:** Entity Framework Core + Npgsql
- **Banco:** PostgreSQL 16 (Docker)
- **Autenticação:** JWT Bearer
- **Documentação:** Swagger / OpenAPI
- **Frontend:** React (em desenvolvimento)

---

## Problemas comuns

### `28P01: autenticação de senha falhou`

O volume do Docker foi criado antes da configuração correta. Execute:

```bash
docker compose down -v
docker compose up -d
cd src/SmartCollect.Api
dotnet ef database update
```

> ⚠️ `down -v` apaga os dados do banco. Use só em desenvolvimento.

### `dotnet-ef não encontrado`

```bash
dotnet tool install --global dotnet-ef --version 10.0.0
```

### `No project was found`

Você está no diretório errado. Execute:

```bash
cd src/SmartCollect.Api
dotnet ef database update
```

---

## Módulos do SmartCollect

| Módulo | Casos de Uso | Status |
|---|---|---|
| M1: Ingestão de Dados | UC01 (Upload), UC02 (API Títulos), UC03 (Ocorrências) | 🔲 A fazer |
| M2: Gestão de Contatos | UC04 (Cadastrar/Editar Contatos) | 🔲 A fazer |
| M3: Régua e Templates | UC05 (Régua), UC06 (Templates) | 🔲 A fazer |
| M4: Motor de Envio | UC07 (Disparos), UC08 (Config SMTP) | 🔲 A fazer |
| Analytics | UC09 (Dashboard KPIs) | 🔲 A fazer |
| Autenticação | UC10 (Login), UC11 (Título Manual) | 🔲 A fazer |

---


