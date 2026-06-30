
# devTask

> Un sistema de gestión de tareas estilo Kanban, de código abierto, diseñado para optimizar el flujo de trabajo y la organización de proyectos.

![Versión](https://img.shields.io/badge/version-1.0.0-blue.svg)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=flat&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)

## Descripción

**devTask** es una aplicación de gestión de tareas basada en la metodología Kanban, desarrollada como proyecto práctico para la clase de Arquitectura de Software. El sistema permite organizar el trabajo en diferentes estados, facilitando la visualización del progreso y la gestión eficiente de las actividades del equipo de desarrollo. 

## Características Principales

* **Tablero Kanban:** Visualización y gestión de tareas en columnas según su estado (ej. Por hacer, En progreso, Completado).
* **Gestión de Tareas:** Creación, lectura, actualización y eliminación (CRUD) ágil de actividades.
* **Persistencia de Datos:** Manejo de base de datos robusto mediante migraciones.
* **Documentación Interactiva:** API completamente documentada y explorable a través de una interfaz gráfica.

## Tecnologías y Arquitectura

Este proyecto está construido con una arquitectura sólida orientada al ecosistema de Microsoft:

* **Lenguaje:** C#
* **Framework:** .NET
* **ORM:** Entity Framework Core
* **Documentación de API:** Swagger / OpenAPI

---

## Instalación y Configuración Local

Sigue estos pasos para compilar y ejecutar **devTask** en tu entorno local.

### Prerrequisitos

Asegúrate de tener instalado:
* [.NET SDK](https://dotnet.microsoft.com/download) (versión correspondiente a tu proyecto)
* Una instancia de base de datos compatible (SQL Server, PostgreSQL o SQLite, según tu configuración)
* [Entity Framework Core tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) (`dotnet tool install --global dotnet-ef`)

### Instalacion

1. **Clonar el repositorio:**
```bash
   git clone [https://github.com/tu-usuario/devtask.git](https://github.com/tu-usuario/devtask.git)
   cd devtask

```


2. **Restaurar dependencias:**
```bash
dotnet restore

```


3. **Configurar la Base de Datos:**
Actualiza la cadena de conexión (`ConnectionString`) en tu archivo `appsettings.json` o `appsettings.Development.json`.


4. **Ejecutar Migraciones:**
Aplica las migraciones de Entity Framework para crear el esquema en tu base de datos:
```bash
dotnet ef database update

```


5. **Iniciar la aplicación:**
```bash
dotnet run

```


La API estará en ejecución (normalmente en `https://localhost:5001` o `http://localhost:5000`).


Una vez que la aplicación esté corriendo, abre tu navegador y visita:
 `https://localhost:<puerto>/swagger`

Allí encontrarás la interfaz interactiva con todos los endpoints disponibles (ej. `/api/tasks`, `/api/boards`), sus esquemas de datos y la opción de probar las peticiones HTTP directamente.

## Contribución

Las contribuciones y mejoras a la arquitectura son bienvenidas:

1. Haz un *Fork* del repositorio.
2. Crea una rama para tu mejora (`git checkout -b feature/mejora-arquitectura`).
3. Haz *Commit* de tus cambios (`git commit -m 'Añade optimización en...'`).
4. Haz *Push* a la rama (`git push origin feature/mejora-arquitectura`).
5. Abre un *Pull Request*.

