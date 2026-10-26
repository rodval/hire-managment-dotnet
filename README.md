# HireManagement API

API REST para gestionar procesos de contratación: empresas publican vacantes, sus empleados las administran y los candidatos se postulan. Construida con **ASP.NET Core (.NET 10)** siguiendo **Clean Architecture** y **CQRS** con MediatR.

## Tecnologías

- .NET 10 / ASP.NET Core Web API
- Entity Framework Core 10 + SQL Server
- MediatR 12.5 (CQRS: commands y queries)
- Mapperly (mapeo entidad ↔ DTO generado en compilación)
- Autenticación JWT Bearer con roles
- Swagger / OpenAPI
- xUnit, Moq y Shouldly para pruebas

## Arquitectura

```
HireManagement.sln
├── HireManagement.Domain        # Entidades y enums, sin dependencias
├── HireManagement.Application   # Casos de uso: commands/queries, handlers, DTOs, contratos
├── HireManagement.Persistence   # EF Core, repositorios, Unit of Work, autenticación JWT
├── HireManagement.API           # Controllers, Swagger, configuración de la app
└── HireManagement.Tests         # Pruebas unitarias de los handlers
```

Las dependencias apuntan hacia adentro: `API → Application ← Persistence`, y `Application → Domain`. Los controllers solo envían requests a MediatR; la lógica vive en los handlers de `Application/Features/<Entidad>/Handlers`.

### Modelo de dominio

| Entidad | Descripción |
| --- | --- |
| `AdminApi` | Administrador de la plataforma. Es dueño de empresas. |
| `Company` | Empresa registrada. |
| `CompanyEmployee` | Empleado de una empresa, de tipo `CompanyAdmin` o `Employee`. |
| `Opening` | Vacante publicada por un empleado (`Valid` o `Finalized`). |
| `Candidate` | Persona que busca empleo. |
| `OpeningApplication` | Postulación de un candidato (`InProcess`, `Stage1`, `Stage2`, `Accepted`, `Rejected`). |

## Requisitos

- [.NET SDK 10.0.100](https://dotnet.microsoft.com/download) o superior (ver `global.json`)
- SQL Server. Por defecto se usa LocalDB (solo Windows); en macOS o Linux se puede usar Docker:

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<TuPassword>" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

## Configuración

`HireManagement.API/appsettings.json` contiene:

- `ConnectionStrings:HireManagementConnectionString`: cadena de conexión a SQL Server.
- `JwtSettings:Key`: clave para firmar los tokens.
- `JwtSettings:DurationInMinutes`: duración del token.

Para no guardar valores sensibles en el repositorio, sobreescríbelos con user secrets:

```bash
dotnet user-secrets --project HireManagement.API set "JwtSettings:Key" "<clave-larga-y-aleatoria>"
```

```bash
dotnet user-secrets --project HireManagement.API set "ConnectionStrings:HireManagementConnectionString" "Server=localhost,1433;Database=hiremanagement_db;User Id=sa;Password=<TuPassword>;TrustServerCertificate=True"
```

## Puesta en marcha

1. Restaurar herramientas locales (incluye `dotnet-ef`):

   ```bash
   dotnet tool restore
   ```

2. Crear la base de datos y aplicar migraciones:

   ```bash
   dotnet ef database update --project HireManagement.Persistence --startup-project HireManagement.API
   ```

3. Ejecutar la API:

   ```bash
   dotnet run --project HireManagement.API
   ```

4. Abrir Swagger en localhost.

## Autenticación y roles

Cada tipo de usuario tiene su propio endpoint de login, que devuelve un JWT:

| Endpoint | Rol en el token |
| --- | --- |
| `POST /api/Account/admin/login` | `Administrator` |
| `POST /api/Account/employee/login` | `CompanyAdmin` o `Employee` |
| `POST /api/Account/candidate/login` | `Candidate` |

En Swagger, pulsa **Authorize** y pega el token.

## Endpoints

Todos los recursos exponen `GET` (lista), `GET /{id}`, `POST`, `PUT` y `DELETE /{id}`.

| Recurso | Ruta | Acceso |
| --- | --- | --- |
| Administradores | `/api/AdminApi` | `Administrator` |
| Empresas | `/api/Company` | `Administrator` |
| Empleados | `/api/CompanyEmployee` | Lista, alta y baja: `Administrator`. Consulta y edición: también `CompanyAdmin` y `Employee` |
| Vacantes | `/api/Opening` | Lista pública (anónima). Resto: `Administrator`, `CompanyAdmin`, `Employee` |
| Candidatos | `/api/Candidate` | Registro (`POST`) anónimo. Consulta y edición: también `Candidate` |
| Postulaciones | `/api/OpeningApplication` | `Administrator`, `CompanyAdmin`, `Employee`. Los candidatos pueden postularse (`POST`) y ver las suyas en `GET /candidates/{candidateId}` |

## Pruebas

```bash
dotnet test
```

Las pruebas cubren los handlers de commands y queries de cada entidad usando repositorios simulados con Moq (`HireManagement.Tests/Mocks`).
# rodval-hire-managment-dotnet
# rodval-hire-managment-dotnet
