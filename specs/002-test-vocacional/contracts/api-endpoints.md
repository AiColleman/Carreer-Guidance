# API Contracts: VocationalTestController

## GET /Test/Start
- **Description**: Genera una nueva sesión (`Guid`), carga las actividades aleatoriamente y renderiza la vista principal.
- **Response**: HTML View.

## POST /Test/Swipe
- **Description**: Recibe la respuesta del estudiante a una actividad y la guarda en la base de datos.
- **Request Body** (JSON):
  ```json
  {
    "sesionId": "00000000-0000-0000-0000-000000000000",
    "actividadId": 1,
    "meInteresa": true
  }
  ```
- **Response**: `200 OK` (Empty or JSON status).

## GET /Test/Results/{sesionId}
- **Description**: Recupera las respuestas de la sesión, calcula los puntos de cada área y renderiza las 2 áreas ganadoras.
- **Response**: HTML View.
