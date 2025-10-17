# EverCodes.Backend.DynamicForm

API Backend para generación y gestión de formularios dinámicos utilizando la estructura de la libreria de Formly.

## 📋 Descripción

API RESTful en .NET 8 que genera formularios dinámicos con validaciones, opciones y agrupaciones de campos. Soporta DTOs para evitar referencias circulares y está lista para integrarse con aplicaciones frontend.

## 🚀 Tecnologías

- **.NET 8.0** - Framework
- **ASP.NET Core Web API** - API REST
- **xUnit** - Testing unitario e integración
- **Swagger/OpenAPI** - Documentación
- **CORS** - Configurado para Angular

## 📁 Estructura del Proyecto

```text
EverCodes.Backend.DynamicForm/
├── src/
│   └── EverCodes.Backend.DynamicForm.Web.API/
│       ├── DynamicForm/
│       │   ├── Controllers/          # API Controllers
│       │   ├── DTOs/                 # Data Transfer Objects (sin ciclos)
│       │   ├── Entities/v2/          # Entidades del dominio
│       │   ├── Mappers/              # Mapeo Entidades → DTOs
│       │   └── MockData/             # Datos de prueba
│       ├── Program.cs                # Configuración de la API
│       └── Properties/
│           └── launchSettings.json   # Perfiles de ejecución
├── tests/
│   └── EverCodes.Backend.DynamicForm.Tests/
│       ├── IntegrationTests/         # Tests de API (WebApplicationFactory)
│       ├── UnitTests/                # Tests unitarios
│       └── TestData/                 # Datos reutilizables para tests
└── .vscode/
    ├── launch.json                   # Configuración debug VS Code
    └── tasks.json                    # Tareas de build
```

## �️ Instalación

```powershell
# Clonar repositorio
git clone https://github.com/Everlm/EverCodes.Backend.DynamicForm.git
cd EverCodes.Backend.DynamicForm

# Restaurar y compilar
dotnet restore
dotnet build
```

## ▶️ Ejecutar

```powershell
# Desde terminal
dotnet run --project src/EverCodes.Backend.DynamicForm.Web.API

# Desde VS Code
# Presiona F5 (usa perfil "http" de launchSettings.json)
```

**URLs disponibles:**

- HTTP: `http://localhost:5059`
- Swagger: `http://localhost:5059/swagger`

## 🔗 Endpoints

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/dynamic-forms/sample` | Formulario con relaciones (IgnoreCycles) |
| `GET` | `/api/dynamic-forms/sample-dto` | Formulario sin ciclos (DTOs) ⭐ |

## 🧪 Testing

```powershell
# Ejecutar todos los tests
dotnet test

# Solo tests unitarios
dotnet test --filter "FullyQualifiedName~UnitTests"

# Solo tests de integración
dotnet test --filter "FullyQualifiedName~IntegrationTests"
```

**Cobertura de tests:**

- ✅ Relaciones entre entidades (Form → Fields → Props → Options)
- ✅ Validaciones y estructura de datos
- ✅ Tests de integración API (WebApplicationFactory)
- ✅ Mappers y DTOs

## 🏗️ Arquitectura

### Entidades Principales

- **FormlyForm**: Contenedor del formulario
- **FormlyFieldConfig**: Configuración de campos (con soporte para FieldGroups)
- **FormlyFieldProp**: Propiedades del campo (tipo, label, validaciones)
- **FormlyFieldOption**: Opciones para selects
- **FormlyValidation**: Mensajes de validación

### Estrategia de Serialización

1. **Endpoint `/sample`**: Usa `ReferenceHandler.IgnoreCycles` (mantiene relaciones)
2. **Endpoint `/sample-dto`**: Usa DTOs sin referencias circulares (recomendado para producción)

## 📝 Comandos Útiles

```powershell
dotnet build                  # Compilar
dotnet run                    # Ejecutar API
dotnet test                   # Ejecutar tests
dotnet clean                  # Limpiar build
```

## 👤 Autor

**Everlm** - [@Everlm](https://github.com/Everlm)

## 📄 Licencia

MIT License
