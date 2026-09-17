# Implementation Plan: Test Vocacional Interactivo

**Branch**: `002-test-vocacional` | **Date**: 2026-09-16 | **Spec**: [2_Specify.md](file:///c:/Users/Asus%20TUF/Desktop/TEST%20VOCACIONAL/2_Specify.md)

**Input**: Feature specification from `/specs/002-test-vocacional/spec.md`

## Summary
Aplicación web interactiva MVC (.NET 8) que digitaliza un test vocacional de 80 actividades. El frontend usa Vanilla JS y Bootstrap 5 para implementar un sistema de tarjetas deslizables (swipe). El backend usa EF Core y SQL Server para almacenar las áreas, actividades, sesiones y respuestas.

## Technical Context
**Language/Version**: C# 12, .NET 8
**Primary Dependencies**: ASP.NET Core MVC, Entity Framework Core, Bootstrap 5
**Storage**: SQL Server
**Testing**: MSTest, Testcontainers
**Target Platform**: Web application
**Project Type**: MVC Web App
**Performance Goals**: N/A
**Constraints**: SOLID, Clean Code, Test-First
**Scale/Scope**: 5 Areas, 80 Actividades, Respuestas por sesión.

## Constitution Check
*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*
- [x] Does this plan adhere to the strictly defined Tech Stack (C#, .NET 8 MVC, SQL Server, EF Core, HTML5/CSS3/BS5/VanillaJS)? **YES**
- [x] Are all classes designed with a single responsibility (SOLID)? **YES**
- [x] Does the plan avoid making business rule/data assumptions outside of `2_Specify.md`? **YES**
- [x] Is there a clear path for Test-First (MSTest/Testcontainers) before task completion? **YES**

## User Review Required
> [!IMPORTANT]
> Please review this architecture plan and confirm if it meets all expectations before we proceed to execution.

## Open Questions
None. Everything is strictly defined by the user and `2_Specify.md`.

## Project Structure
### Documentation (this feature)
```text
specs/002-test-vocacional/
├── plan.md              # This file
├── research.md          # Phase 0 output
├── data-model.md        # Phase 1 output
├── quickstart.md        # Phase 1 output
├── contracts/           # Phase 1 output
└── tasks.md             # Phase 2 output (/speckit-tasks command)
```

### Source Code (repository root)
```text
src/
├── Web/                # Proyecto MVC (.NET 8)
├── Core/               # Modelos de Dominio
└── Data/               # VocationalDbContext, EF Core, Seed Data

tests/
├── UnitTests/          # Pruebas MSTest (TC-01, TC-02)
└── IntegrationTests/   # Pruebas Testcontainers (TC-03)
```
**Structure Decision**: El proyecto usará una arquitectura multicapas estricta con Web, Core, Data y Tests.

## Verification Plan

### Automated Tests
- Ejecutar `dotnet test` para validar las pruebas TC-01, TC-02, y TC-03.

### Manual Verification
- Levantar la app con `dotnet run`.
- Visitar la URL y hacer clic 80 veces para interactuar con las preguntas.
- Validar que se guardaron las preguntas correctamente y se muestran las 2 áreas finales.
