# EverCodes.Backend.DynamicForm

API Backend para generación y gestión de formularios dinámicos.

## 📋 Descripción

Este proyecto es una API RESTful desarrollada en .NET 8 que proporciona servicios para la creación y gestión de formularios dinámicos. Permite definir formularios con diferentes tipos de campos (texto, email, select, checkbox, etc.) que pueden ser consumidos por aplicaciones frontend.

## 🚀 Tecnologías

- **.NET 8.0** - Framework principal
- **ASP.NET Core** - Web API
- **Swagger/OpenAPI** - Documentación de API
- **CORS** - Configurado para Angular (puerto 4200)

## 📁 Estructura del Proyecto

```
EverCodes.Backend.DynamicForm/
├── src/
│   └── EverCodes.Backend.DynamicForm.Web.API/
│       ├── DynamicForm/
│       │   ├── Controllers/      # Controladores de la API
│       │   ├── Dtos/             # Objetos de transferencia de datos
│       │   └── MockData/         # Datos de prueba
│       ├── Program.cs            # Punto de entrada de la aplicación
│       └── *.csproj              # Archivo de proyecto
└── EverCodes.Backend.DynamicForm.sln
```

## 🛠️ Requisitos Previos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio Code (recomendado) o Visual Studio 2022

## 📦 Instalación

1. Clonar el repositorio:
```powershell
git clone https://github.com/Everlm/EverCodes.Backend.DynamicForm.git
cd EverCodes.Backend.DynamicForm
```

2. Restaurar las dependencias:
```powershell
dotnet restore
```

3. Compilar el proyecto:
```powershell
dotnet build
```

## ▶️ Ejecutar el Proyecto

### Desde la terminal:
```powershell
dotnet run --project src/EverCodes.Backend.DynamicForm.Web.API/EverCodes.Backend.DynamicForm.Web.API.csproj
```

### Desde VS Code:
Presiona `F5` para ejecutar en modo debug.

La API estará disponible en:
- **HTTPS**: `https://localhost:5001`
- **HTTP**: `http://localhost:5000`
- **Swagger UI**: `https://localhost:5001/swagger`

## 🔗 Endpoints Principales

### Obtener Definición de Formulario
```
GET /api/DynamicForm
```
Retorna la definición completa de un formulario dinámico con todos sus campos.

## 🔧 Configuración de CORS

La API está configurada para aceptar peticiones desde:
- `http://localhost:4200` (Angular Development)
- `https://localhost:4200` (Angular Development SSL)

Para modificar los orígenes permitidos, edita el archivo `Program.cs`.

## 📝 Comandos Útiles

```powershell
# Compilar
dotnet build

# Ejecutar
dotnet run

# Limpiar build
dotnet clean

```

## 👤 Autor

**Everlm**
- GitHub: [@Everlm](https://github.com/Everlm)

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo LICENSE para más detalles.