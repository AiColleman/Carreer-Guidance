# Feature Specification: Reglas, Datos y Pruebas del Sistema

**Feature Branch**: `002-test-vocacional`
**Created**: 2026-09-16
**Status**: Draft

## 1. Visión General y Reglas de Negocio
Aplicación web interactiva que digitaliza un test vocacional mediante un sistema de "tarjetas deslizables" (swipe cards) para maximizar la retención del estudiante.
*   **BR-01:** El sistema maneja 5 áreas vocacionales fijas.
*   **BR-02:** El test consta de 80 actividades exactas.
*   **BR-03:** El estudiante marca "Me interesa" (suma 1 punto a su área) o "No me interesa" (suma 0 puntos).
*   **BR-04:** Al finalizar, el sistema calcula los puntos, ordena de mayor a menor y devuelve las 2 áreas con mayor puntaje (primera y segunda opción).

## 2. Entidades (Domain Models)
*   **Area:** `Id` (int, PK), `Nombre` (string).
*   **Actividad:** `Id` (int, PK), `Numero` (int), `TextoActividad` (string), `AreaId` (int, FK).
*   **Sesion:** `Id` (Guid, PK), `FechaCreacion` (DateTime).
*   **Respuesta:** `Id` (int, PK), `SesionId` (Guid, FK), `ActividadId` (int, FK), `MeInteresa` (bool).

## 3. Especificación de Pruebas (TestSpec)
*   **TC-01 (Unitario - MSTest):** `VocationalScoreCalculator`. Simular 80 respuestas. Asignar 15 respuestas True al Área 1 y menos de 10 al resto. Verificar que devuelva el Área 1 como primera opción.
*   **TC-02 (Unitario - MSTest):** Manejar empates en el primer lugar devolviendo ambas áreas sin lanzar excepciones.
*   **TC-03 (Integración - Testcontainers SQL Server):** Verificar que al inicializar la BD, existan exactamente 5 registros en `Areas` y 80 en `Actividades`.

## 4. Datos Iniciales (Seed Data)
El agente debe poblar la base de datos exactamente con esta información en `OnModelCreating`:

### Áreas
1: Arte y Creatividad | 2: Ciencias Sociales | 3: Económica, Administrativa y Financiera | 4: Ciencia y Tecnología | 5: Ciencias Ecológicas, Biológicas y de la Salud

### Actividades (Formato: Numero | AreaId | TextoActividad)
1 | 4 | Diseñar programas de computación y explorar nuevas aplicaciones tecnológicas para uso del internet
2 | 5 | Criar, cuidar y tratar animales domésticos y de campo
3 | 5 | Investigar sobre áreas verdes, medio ambiente y cambios climáticos
4 | 1 | Ilustrar, dibujar y animar digitalmente
5 | 3 | Seleccionar, capacitar y motivar al personal de una organización/empresa
6 | 2 | Realizar excavaciones para descubrir restos del pasado
7 | 4 | Resolver problemas de cálculo para construir un puente
8 | 5 | Diseñar cursos para enseñar a la gente sobre temas de salud e higiene
9 | 1 | Tocar un instrumento y componer música
10 | 3 | Planificar cuáles son las metas de una organización pública o privada a mediano y largo plazo
11 | 4 | Diseñar y planificar la producción masiva de artículos como muebles, autos, equipos de oficina, empaques y envases para alimentos y otros
12 | 1 | Diseñar logotipos y portadas de una revista
13 | 2 | Organizar eventos y atender a sus asistentes
14 | 5 | Atender la salud de personas enfermas
15 | 3 | Controlar ingresos y egresos de fondos y presentar el balance final de una institución
16 | 5 | Hacer experimentos con plantas (frutas, árboles, flores)
17 | 4 | Concebir planos para viviendas, edificios y ciudadelas
18 | 5 | Investigar y probar nuevos productos farmacéuticos
19 | 3 | Hacer propuestas y formular estrategias para aprovechar las relaciones económicas entre dos países
20 | 1 | Pintar, hacer esculturas, ilustrar libros de arte, etcétera
21 | 3 | Elaborar campañas para introducir un nuevo producto al mercado
22 | 5 | Examinar y tratar los problemas visuales
23 | 2 | Defender a clientes individuales o empresas en juicios de diferente naturaleza
24 | 4 | Diseñar máquinas que puedan simular actividades humanas
25 | 2 | Investigar las causas y efectos de los trastornos emocionales
26 | 3 | Supervisar las ventas de un centro comercial
27 | 5 | Atender y realizar ejercicios a personas que tienen limitaciones físicas, problemas de lenguaje, etcétera
28 | 1 | Prepararse para ser modelo profesional
29 | 3 | Aconsejar a las personas sobre planes de ahorro e inversiones
30 | 4 | Elaborar mapas, planos e imágenes para el estudio y análisis de datos geográficos
31 | 1 | Diseñar juegos interactivos electrónicos para computadora
32 | 5 | Realizar el control de calidad de los alimentos
33 | 3 | Tener un negocio propio de tipo comercial
34 | 2 | Escribir artículos periodísticos, cuentos, novelas y otros
35 | 1 | Redactar guiones y libretos para un programa de televisión
36 | 3 | Organizar un plan de distribución y venta de un gran almacén
37 | 2 | Estudiar la diversidad cultural en el ámbito rural y urbano
38 | 2 | Gestionar y evaluar convenios internacionales de cooperación para el desarrollo social
39 | 1 | Crear campañas publicitarias
40 | 5 | Trabajar investigando la reproducción de peces, camarones y otros animales marinos
41 | 4 | Dedicarse a fabricar productos alimenticios de consumo masivo
42 | 2 | Gestionar y evaluar proyectos de desarrollo en una institución educativa y/o fundación
43 | 1 | Rediseñar y decorar espacios físicos en viviendas, oficinas y locales comerciales
44 | 3 | Administrar una empresa de turismo y/o agencias de viaje
45 | 5 | Aplicar métodos alternativos a la medicina tradicional para atender personas con dolencias de diversa índole
46 | 1 | Diseñar ropa para niños, jóvenes y adultos
47 | 5 | Investigar organismos vivos para elaborar vacunas
48 | 4 | Manejar y/o dar mantenimiento a dispositivos/aparatos tecnológicos en aviones, barcos, radares, etcétera
49 | 2 | Estudiar idiomas extranjeros -actuales y antiguos- para hacer traducción
50 | 1 | Restaurar piezas y obras de arte
51 | 4 | Revisar y dar mantenimiento a artefactos eléctricos, electrónicos y computadoras
52 | 2 | Enseñar a niños de 0 a 5 años
53 | 3 | Investigar y/o sondear nuevos mercados
54 | 5 | Atender la salud dental de las personas
55 | 2 | Tratar a niños, jóvenes y adultos con problemas psicológicos
56 | 3 | Crear estrategias de promoción y venta de nuevos productos ecuatorianos en el mercado internacional
57 | 5 | Planificar y recomendar dietas para personas diabéticas y/o con sobrepeso
58 | 4 | Trabajar en una empresa petrolera en un cargo técnico como control de la producción
59 | 3 | Administrar una empresa (familiar, privada o pública)
60 | 4 | Tener un taller de reparación y mantenimiento de carros, tractores, etcétera
61 | 4 | Ejecutar proyectos de extracción minera y metalúrgica
62 | 3 | Asistir a directivos de multinacionales con manejo de varios idiomas
63 | 2 | Diseñar programas educativos para niños con discapacidad
64 | 4 | Aplicar conocimientos de estadística en investigaciones en diversas áreas (social, administrativa, salud, etcétera)
65 | 1 | Fotografiar hechos históricos, lugares significativos, rostros, paisajes para el área publicitaria, artística, periodística y social
66 | 2 | Trabajar en museos y bibliotecas nacionales e internacionales
67 | 1 | Ser parte de un grupo de teatro
68 | 1 | Producir cortometrajes, spots publicitarios, programas educativos, de ficción, etcétera
69 | 5 | Estudiar la influencia entre las corrientes marinas y el clima y sus consecuencias ecológicas
70 | 2 | Conocer las distintas religiones, su filosofía y transmitirlas a la comunidad en general
71 | 3 | Asesorar a inversionistas en la compra de bienes/acciones en mercados nacionales e internacionales
72 | 2 | Estudiar grupos étnicos, sus costumbres, tradiciones, cultura y compartir sus vivencias
73 | 4 | Explorar el espacio sideral, los planetas, sus características y componentes
74 | 5 | Mejorar la imagen facial y corporal de las personas aplicando diferentes técnicas
75 | 1 | Decorar jardines de casas y parques públicos
76 | 5 | Administrar y renovar menúes de comidas en un hotel o restaurante
77 | 1 | Trabajar como presentador de televisión, locutor de radio y televisión, animador de programas culturales y concursos
78 | 2 | Diseñar y ejecutar programas de turismo
79 | 4 | Administrar y ordenar (planificar) adecuadamente la ocupación del espacio físico de ciudades, países, etc., utilizando imágenes de satélite, mapas
80 | 3 | Organizar, planificar y administrar centros educativos
