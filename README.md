# Full-Stack Monorepo Template

[![CI/CD Pipeline](https://github.com/phatom2005/nextjs-dotnet-monorepo-template/actions/workflows/main.yml/badge.svg)](https://github.com/phatom2005/nextjs-dotnet-monorepo-template/actions)
[![CodeQL](https://github.com/phatom2005/nextjs-dotnet-monorepo-template/actions/workflows/codeql.yml/badge.svg)](https://github.com/phatom2005/nextjs-dotnet-monorepo-template/security/code-scanning)
![Security Status](https://img.shields.io/badge/Security-Snyk_Protected-blueviolet?logo=snyk)
![License](https://img.shields.io/badge/License-MIT-green)

*Read this in other languages: [Tiếng Việt](README.vi.md)*

> **Lean, Secure, and Scalable.** 
> A complete project foundation using **Next.js** and **.NET 9**.

This is a powerful project template designed as a monorepo, combining a modern Frontend (Next.js) and a high-performance Backend (.NET 9), pre-configured with a Dockerized environment for both applications along with a PostgreSQL database.

## Tech Stack

- **Frontend:** Next.js 15 (App Router), Tailwind CSS
- **Backend:** .NET 9 Web API, Entity Framework Core
- **Database:** PostgreSQL
- **DevOps:** Docker, Docker Compose, GitHub Actions
- **Security:** Snyk Security Scanning

## Project Structure

```text
.
├── project/
│   ├── frontend/         # Next.js 15 source code
│   └── backend/          # .NET 9 Web API source code
├── docker-compose.yml    # Configuration file to build & run the entire system
├── .env                  # Environment variables file (Database Password)
└── README.md
```

## Getting Started

### 1. Prerequisites
- [Docker & Docker CLI](https://www.docker.com/) (Recommended for a consistent development environment).
- [Node.js](https://nodejs.org/) (If you want to run the frontend independently).
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (If you want to develop and test the backend locally).

### 2. Run with Docker (Development Environment)
The easiest way is to launch the Frontend, Backend, and Database simultaneously with a single command:

1. Ensure your `.env` file has the necessary settings (Defaults to `DB_PASSWORD=YourPassword123` to avoid DB container errors).
2. Open a terminal at the root of this project and run:
   ```bash
   docker compose up --build
   ```
3. After a successful build, the services will be available at:
   - **Frontend (Next.js):** [http://localhost:3000](http://localhost:3000)
   - **Backend API:** [http://localhost:5000](http://localhost:5000)
   - **Database (PostgreSQL):** Port `5432`

> **Note:** The DB Volume is mapped externally, so your database data is preserved even if the container is stopped. Add the `-d` flag (`docker compose up -d`) if you want to run Docker in detached mode (in the background). To stop the services, run `docker compose down`.

### 3. Run Services Individually (Manual)

#### Run Frontend independently (requires Node.js):
```bash
cd project/frontend
npm install
npm run dev
```

#### Run Backend independently (requires .NET 9 SDK):
```bash
cd project/backend/ProjectTemplate-WebApp
dotnet run
```
*(Note: If running manually, ensure PostgreSQL is running locally or modify the database connection string inside `appsettings.Development.json` to match your local DB connection).*

## Customizing the Project 
- **API Project Name:** When you change or create a new project name inside the `backend/` directory (e.g., instead of `ProjectTemplate-WebApp`), remember to open `docker-compose.yml` and update the `dockerfile` path to point to the correct `Dockerfile` you are using.
- **Frontend Environment Variables:** The frontend connects to the backend using the `NEXT_PUBLIC_API_URL` environment variable, which is pre-configured via `.env`/`docker-compose.yml`.

## Security / DevOps
The project comes pre-configured with Github Actions for automated checks and integrates **Snyk Security Scanning** to automatically scan for security vulnerabilities.

---
**Happy Coding!**