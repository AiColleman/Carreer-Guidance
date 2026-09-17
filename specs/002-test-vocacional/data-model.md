# Data Model: Test Vocacional Interactivo

## Entities

### Area
- **Id**: `int` (Primary Key)
- **Nombre**: `string` (Required)

### Actividad
- **Id**: `int` (Primary Key)
- **Numero**: `int` (Required, 1-80)
- **TextoActividad**: `string` (Required)
- **AreaId**: `int` (Foreign Key to Area)

### Sesion
- **Id**: `Guid` (Primary Key)
- **FechaCreacion**: `DateTime` (Required)

### Respuesta
- **Id**: `int` (Primary Key)
- **SesionId**: `Guid` (Foreign Key to Sesion)
- **ActividadId**: `int` (Foreign Key to Actividad)
- **MeInteresa**: `bool` (Required)
