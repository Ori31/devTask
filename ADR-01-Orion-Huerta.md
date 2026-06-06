# ADR-01: Elección del Estilo Arquitectónico Base - Arquitectura en 3 Capas

| Campo  | Valor |
|--------|-------|
| Autor  | Sergio Orion Huerta Martinez |
| Fecha  | 15/05/2026 |
| Estado | `Propuesto`|

---

## Contexto

Estamos construyendo **DevTask**, un sistema de gestión de tareas (To-Do List) dirigido a estudiantes y desarrolladores para organizar proyectos técnicos y académicos. El sistema requiere manejar usuarios, tareas con prioridades y categorías. 

**Restricciones y condiciones:** El proyecto se desarrolla bajo el marco de una asignatura universitaria, lo que implica un tiempo de entrega estricto y recursos limitados. Aunque se debe demostrar la aplicación de buenas prácticas de diseño de software y separación de responsabilidades, la prioridad es mantener un flujo de desarrollo ágil que permita entregar todas las funcionalidades requeridas antes del fin del semestre sin caer en sobreingeniería.

---

## Decisión

Se ha decidido implementar una **Arquitectura clásica de 3 Capas (Presentación, Lógica de Negocio y Acceso a Datos)** utilizando ASP.NET Core para la API y Entity Framework Core.

### ¿Por qué?

Este patrón divide el sistema en responsabilidades claras, manteniendo la interfaz de usuario (o API) separada de las reglas del negocio y de la base de datos, lo cual es un estándar sólido en la industria. La principal razón de esta elección es su **baja fricción de desarrollo**. A diferencia de arquitecturas más complejas, el flujo de datos es lineal y directo, lo que reduce drásticamente la cantidad de código repetitivo (boilerplate) necesario para implementar operaciones CRUD básicas, permitiendo avanzar rápido y cumplir con los tiempos de la materia.

### Alternativas consideradas

| Alternativa | Por qué la descarté |
|-------------|---------------------|
| **Clean Architecture / Arquitectura Hexagonal** | Exige crear demasiadas abstracciones (puertos, adaptadores, múltiples DTOs e interfaces) incluso para operaciones simples. Esto consumiría demasiado tiempo del semestre en configuración en lugar de programar funcionalidades reales. |
| **Monolito acoplado (Todo en el mismo proyecto/controladores)** | Aunque es lo más rápido, mezcla consultas SQL o de Entity Framework directamente en los controladores. Esto viola los principios de diseño exigidos en la clase y hace que el código sea imposible de mantener o reutilizar. |
| **Microservicios** | Añade complejidad de infraestructura innecesaria para el alcance de un To-Do list. Resolver problemas de comunicación en red y despliegue múltiple está fuera del alcance de la materia. |

---

## Consecuencias

**Lo que gano:**

- **Consecuencia técnica:** Aumento significativo en la velocidad de desarrollo. El flujo de datos es fácil de seguir (Controlador -> Servicio -> Repositorio), lo que facilita encontrar errores rápidamente.
- **Consecuencia sobre el proceso/equipo:** La curva de aprendizaje es mínima. Cualquier integrante del equipo puede entender cómo crear una nueva funcionalidad simplemente replicando la estructura de una capa a otra sin perderse en abstracciones complejas.

**Lo que sacrifico o asumo:**

- **Limitación técnica:** El aislamiento para pruebas unitarias (Unit Testing) es menos puro. La capa de negocio suele quedar un poco más acoplada a las tecnologías de acceso a datos (como Entity Framework), lo que obliga a hacer más "mocks" al momento de testear.
- **Deuda o riesgo:** Si el proyecto escalara en el futuro para integrar múltiples bases de datos externas o reglas de negocio extremadamente complejas, esta arquitectura podría volverse rígida, requiriendo una refactorización hacia un modelo de dominio más rico.

## Diagrama

![Diagrama](Screenshot_20260515_215634.png)