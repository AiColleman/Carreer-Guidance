# Feature Specification: Reglas, Datos y Pruebas del Sistema

**Feature Branch**: `002-test-vocacional`

**Created**: 2026-09-16

**Status**: Draft

**Input**: User description: "Specify: Reglas, Datos y Pruebas del Sistema..."

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Realización del Test Vocacional (Priority: P1)

El estudiante interactúa con 80 actividades de forma secuencial a través de un sistema de tarjetas deslizables (swipe cards). Al finalizar, el sistema determina y muestra las dos áreas vocacionales con mayor puntaje.

**Why this priority**: Es el flujo fundamental de la aplicación para poder dar un resultado al usuario.

**Independent Test**: Se puede probar mediante los casos de prueba TC-01 y TC-02 sin depender de la UI completa.

**Acceptance Scenarios**:

1. **Given** un test en curso, **When** el usuario desliza la tarjeta a la derecha ("Me interesa"), **Then** se suma 1 punto al área correspondiente a la actividad.
2. **Given** un test en curso, **When** el usuario desliza la tarjeta a la izquierda ("No me interesa"), **Then** se suman 0 puntos al área correspondiente.
3. **Given** las 80 actividades contestadas, **When** el sistema calcula los resultados, **Then** ordena las áreas de mayor a menor y devuelve las 2 áreas con mayor puntaje (primera y segunda opción).
4. **Given** un empate en el primer lugar de los resultados (TC-02), **When** el sistema calcula los resultados, **Then** devuelve ambas áreas empatadas sin lanzar excepciones.

---

### Edge Cases

- ¿Qué pasa si hay un empate triple en el primer lugar o un empate en el segundo lugar? (Según TC-02, el sistema maneja empates devolviendo las áreas involucradas sin excepciones. Se asume que retornará todas las áreas empatadas en los lugares solicitados).

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: El sistema MUST manejar exactamente 5 áreas vocacionales: Arte y Creatividad; Ciencias Sociales; Económica, Administrativa y Financiera; Ciencia y Tecnología; Ciencias Ecológicas, Biológicas y de la Salud (BR-01).
- **FR-002**: El cuestionario MUST constar de 80 actividades exactas, cada una asignada a un área (BR-02).
- **FR-003**: El sistema MUST presentar una interfaz de "tarjetas deslizables" (swipe cards) para mostrar las actividades una por una.
- **FR-004**: El sistema MUST permitir marcar "Me interesa" (suma 1 punto al área) o "No me interesa" (suma 0 puntos) (BR-03).
- **FR-005**: Al finalizar, el sistema MUST calcular los puntos, ordenar de mayor a menor y devolver las 2 áreas con mayor puntaje (BR-04).
- **FR-006**: La base de datos MUST ser poblada (Seed Data) en `OnModelCreating` con las 5 áreas y las 80 actividades exactas especificadas por el usuario.

### Key Entities

- **Area**: `Id` (int, PK), `Nombre` (string).
- **Actividad**: `Id` (int, PK), `Numero` (int), `TextoActividad` (string), `AreaId` (int, FK).
- **Sesion**: `Id` (Guid, PK), `FechaCreacion` (DateTime).
- **Respuesta**: `Id` (int, PK), `SesionId` (Guid, FK), `ActividadId` (int, FK), `MeInteresa` (bool).

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: Todas las pruebas automatizadas (TC-01, TC-02, TC-03) MUST ejecutarse y pasar correctamente (MSTest y Testcontainers).
- **SC-002**: El sistema registra 80 respuestas por sesión y calcula el resultado correctamente para el 100% de los tests finalizados.
- **SC-003**: La inicialización de la base de datos inserta exactamente 5 registros en `Areas` y 80 en `Actividades`.

## Assumptions

- No se requiere un registro complejo de usuarios para iniciar una sesión; se utiliza un `Guid` anónimo generado al inicio.
- Se asume que el sistema debe manejar empates devolviendo más de 2 áreas si hay múltiples áreas empatadas en los primeros dos puntajes más altos (basado en la instrucción del TC-02 "Manejar empates en el primer lugar devolviendo ambas áreas").
