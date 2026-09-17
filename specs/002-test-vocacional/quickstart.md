# Quickstart: Validation Guide

## Setup
1. Asegurarse de tener Docker corriendo para levantar la instancia SQL Server mediante Testcontainers (o tu motor local según se configure).
2. Restaurar paquetes y compilar solución: `dotnet build`.
3. Ejecutar la batería de pruebas: `dotnet test`.
   - Se debe verificar que pasan las pruebas unitarias (TC-01, TC-02).
   - Se debe verificar que pasa la prueba de integración (TC-03) validando que se insertaron las áreas y las 80 actividades correctamente.

## Manual Validation
1. Moverse al directorio del proyecto `Web` e iniciar la aplicación: `dotnet run`.
2. Navegar en un navegador a `http://localhost:xxxx/Test/Start`.
3. El sistema presentará la vista y cargará 80 tarjetas.
4. Interactuar con las tarjetas deslizables (marcar "Me interesa" o "No me interesa" según los controles de la UI) un total de 80 veces.
5. Al finalizar las actividades, verificar que se redirige automáticamente a `http://localhost:xxxx/Test/Results/{sesionId}`.
6. En la pantalla de resultados, comprobar que aparecen las 2 áreas vocacionales que obtuvieron más puntos.
