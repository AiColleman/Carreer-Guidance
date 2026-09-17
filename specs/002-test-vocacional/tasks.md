# Tasks: Reglas, Datos y Pruebas del Sistema

**Input**: Design documents from `/specs/002-test-vocacional/`

**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/

**Tests**: The examples below include test tasks. Tests are MANDATORY as per the Constitution (Test-First principle) and MUST be written and pass before tasks are completed.

**Organization**: Tasks are grouped by user story to enable independent implementation and testing of each story.

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel (different files, no dependencies)
- **[Story]**: Which user story this task belongs to (e.g., US1, US2, US3)
- Include exact file paths in descriptions

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Project initialization and basic structure

- [x] T001 [P] Crear la solución .NET 8 y los proyectos (Core, Data, Web, Tests) en `src/` y `tests/`
- [x] T002 [P] Configurar Testcontainers con SQL Server en `tests/IntegrationTests/TestcontainersSetup.cs`

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core infrastructure that MUST be complete before ANY user story can be implemented

**⚠️ CRITICAL**: No user story work can begin until this phase is complete

- [x] T003 [P] Crear entidades (Area, Actividad, Sesion, Respuesta) en `src/Core/Entities/`
- [x] T004 Configurar `VocationalDbContext` e implementar el Seeding (leyendo de `2_Specify.md`) en `src/Data/VocationalDbContext.cs`
- [x] T005 Aplicar migración inicial de EF Core usando el proyecto `Data`

**Checkpoint**: Foundation ready - user story implementation can now begin in parallel

---

## Phase 3: User Story 1 - Realización del Test Vocacional (Priority: P1) 🎯 MVP

**Goal**: El estudiante interactúa con 80 actividades mediante tarjetas deslizables y obtiene sus dos áreas vocacionales con mayor puntaje.

**Independent Test**: Se puede probar ejecutando los tests unitarios y de integración para validar cálculos de puntaje y población de base de datos, así como la interacción en frontend.

### Tests for User Story 1 ⚠️

> **NOTE: Write these tests FIRST, ensure they FAIL before implementation**

- [x] T006 [P] [US1] Escribir prueba unitaria TC-01 y TC-02 para el calculador de áreas en `tests/UnitTests/VocationalScoreCalculatorTests.cs`
- [x] T007 [P] [US1] Escribir prueba de integración TC-03 para verificar el correcto llenado de la BD en `tests/IntegrationTests/DatabaseInitializationTests.cs` ⚠️ Requiere Docker Desktop activo

### Implementation for User Story 1

- [x] T008 [US1] Implementar la lógica de cálculo (VocationalScoreCalculator) en `src/Core/Services/VocationalScoreCalculator.cs`
- [x] T009 [US1] Crear controlador con los endpoints correspondientes en `src/Web/Controllers/VocationalTestController.cs`
- [x] T010 [P] [US1] Construir vista Razor principal (tarjetas apiladas) en `src/Web/Views/Test/Start.cshtml`
- [x] T011 [P] [US1] Construir vista Razor de resultados en `src/Web/Views/Test/Results.cshtml`
- [x] T012 [P] [US1] Escribir Vanilla JavaScript para detectar Swipe, Fetch asíncrono y animar tarjetas en `src/Web/wwwroot/js/test-vocacional.js`
- [x] T013 [P] [US1] Añadir estilos CSS para las tarjetas en `src/Web/wwwroot/css/test-vocacional.css`

**Checkpoint**: At this point, User Story 1 should be fully functional and testable independently

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies - can start immediately
- **Foundational (Phase 2)**: Depends on Setup completion - BLOCKS all user stories
- **User Stories (Phase 3+)**: Depend on Foundational phase completion

### Within Each User Story

- Tests MUST be written and FAIL before implementation (Test-First constitution rule).
