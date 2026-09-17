using System;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Data
{
    public class VocationalDbContext : DbContext
    {
        public VocationalDbContext(DbContextOptions<VocationalDbContext> options) : base(options) { }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Areas
            modelBuilder.Entity<Area>().HasData(
                new Area { Id = 1, Nombre = "Arte y Creatividad" },
                new Area { Id = 2, Nombre = "Ciencias Sociales" },
                new Area { Id = 3, Nombre = "Económica, Administrativa y Financiera" },
                new Area { Id = 4, Nombre = "Ciencia y Tecnología" },
                new Area { Id = 5, Nombre = "Ciencias Ecológicas, Biológicas y de la Salud" }
            );

            // Seed Actividades
            modelBuilder.Entity<Actividad>().HasData(
                new Actividad { Id = 1, Numero = 1, AreaId = 4, TextoActividad = "Diseñar programas de computación y explorar nuevas aplicaciones tecnológicas para uso del internet" },
                new Actividad { Id = 2, Numero = 2, AreaId = 5, TextoActividad = "Criar, cuidar y tratar animales domésticos y de campo" },
                new Actividad { Id = 3, Numero = 3, AreaId = 5, TextoActividad = "Investigar sobre áreas verdes, medio ambiente y cambios climáticos" },
                new Actividad { Id = 4, Numero = 4, AreaId = 1, TextoActividad = "Ilustrar, dibujar y animar digitalmente" },
                new Actividad { Id = 5, Numero = 5, AreaId = 3, TextoActividad = "Seleccionar, capacitar y motivar al personal de una organización/empresa" },
                new Actividad { Id = 6, Numero = 6, AreaId = 2, TextoActividad = "Realizar excavaciones para descubrir restos del pasado" },
                new Actividad { Id = 7, Numero = 7, AreaId = 4, TextoActividad = "Resolver problemas de cálculo para construir un puente" },
                new Actividad { Id = 8, Numero = 8, AreaId = 5, TextoActividad = "Diseñar cursos para enseñar a la gente sobre temas de salud e higiene" },
                new Actividad { Id = 9, Numero = 9, AreaId = 1, TextoActividad = "Tocar un instrumento y componer música" },
                new Actividad { Id = 10, Numero = 10, AreaId = 3, TextoActividad = "Planificar cuáles son las metas de una organización pública o privada a mediano y largo plazo" },
                new Actividad { Id = 11, Numero = 11, AreaId = 4, TextoActividad = "Diseñar y planificar la producción masiva de artículos como muebles, autos, equipos de oficina, empaques y envases para alimentos y otros" },
                new Actividad { Id = 12, Numero = 12, AreaId = 1, TextoActividad = "Diseñar logotipos y portadas de una revista" },
                new Actividad { Id = 13, Numero = 13, AreaId = 2, TextoActividad = "Organizar eventos y atender a sus asistentes" },
                new Actividad { Id = 14, Numero = 14, AreaId = 5, TextoActividad = "Atender la salud de personas enfermas" },
                new Actividad { Id = 15, Numero = 15, AreaId = 3, TextoActividad = "Controlar ingresos y egresos de fondos y presentar el balance final de una institución" },
                new Actividad { Id = 16, Numero = 16, AreaId = 5, TextoActividad = "Hacer experimentos con plantas (frutas, árboles, flores)" },
                new Actividad { Id = 17, Numero = 17, AreaId = 4, TextoActividad = "Concebir planos para viviendas, edificios y ciudadelas" },
                new Actividad { Id = 18, Numero = 18, AreaId = 5, TextoActividad = "Investigar y probar nuevos productos farmacéuticos" },
                new Actividad { Id = 19, Numero = 19, AreaId = 3, TextoActividad = "Hacer propuestas y formular estrategias para aprovechar las relaciones económicas entre dos países" },
                new Actividad { Id = 20, Numero = 20, AreaId = 1, TextoActividad = "Pintar, hacer esculturas, ilustrar libros de arte, etcétera" },
                new Actividad { Id = 21, Numero = 21, AreaId = 3, TextoActividad = "Elaborar campañas para introducir un nuevo producto al mercado" },
                new Actividad { Id = 22, Numero = 22, AreaId = 5, TextoActividad = "Examinar y tratar los problemas visuales" },
                new Actividad { Id = 23, Numero = 23, AreaId = 2, TextoActividad = "Defender a clientes individuales o empresas en juicios de diferente naturaleza" },
                new Actividad { Id = 24, Numero = 24, AreaId = 4, TextoActividad = "Diseñar máquinas que puedan simular actividades humanas" },
                new Actividad { Id = 25, Numero = 25, AreaId = 2, TextoActividad = "Investigar las causas y efectos de los trastornos emocionales" },
                new Actividad { Id = 26, Numero = 26, AreaId = 3, TextoActividad = "Supervisar las ventas de un centro comercial" },
                new Actividad { Id = 27, Numero = 27, AreaId = 5, TextoActividad = "Atender y realizar ejercicios a personas que tienen limitaciones físicas, problemas de lenguaje, etcétera" },
                new Actividad { Id = 28, Numero = 28, AreaId = 1, TextoActividad = "Prepararse para ser modelo profesional" },
                new Actividad { Id = 29, Numero = 29, AreaId = 3, TextoActividad = "Aconsejar a las personas sobre planes de ahorro e inversiones" },
                new Actividad { Id = 30, Numero = 30, AreaId = 4, TextoActividad = "Elaborar mapas, planos e imágenes para el estudio y análisis de datos geográficos" },
                new Actividad { Id = 31, Numero = 31, AreaId = 1, TextoActividad = "Diseñar juegos interactivos electrónicos para computadora" },
                new Actividad { Id = 32, Numero = 32, AreaId = 5, TextoActividad = "Realizar el control de calidad de los alimentos" },
                new Actividad { Id = 33, Numero = 33, AreaId = 3, TextoActividad = "Tener un negocio propio de tipo comercial" },
                new Actividad { Id = 34, Numero = 34, AreaId = 2, TextoActividad = "Escribir artículos periodísticos, cuentos, novelas y otros" },
                new Actividad { Id = 35, Numero = 35, AreaId = 1, TextoActividad = "Redactar guiones y libretos para un programa de televisión" },
                new Actividad { Id = 36, Numero = 36, AreaId = 3, TextoActividad = "Organizar un plan de distribución y venta de un gran almacén" },
                new Actividad { Id = 37, Numero = 37, AreaId = 2, TextoActividad = "Estudiar la diversidad cultural en el ámbito rural y urbano" },
                new Actividad { Id = 38, Numero = 38, AreaId = 2, TextoActividad = "Gestionar y evaluar convenios internacionales de cooperación para el desarrollo social" },
                new Actividad { Id = 39, Numero = 39, AreaId = 1, TextoActividad = "Crear campañas publicitarias" },
                new Actividad { Id = 40, Numero = 40, AreaId = 5, TextoActividad = "Trabajar investigando la reproducción de peces, camarones y otros animales marinos" },
                new Actividad { Id = 41, Numero = 41, AreaId = 4, TextoActividad = "Dedicarse a fabricar productos alimenticios de consumo masivo" },
                new Actividad { Id = 42, Numero = 42, AreaId = 2, TextoActividad = "Gestionar y evaluar proyectos de desarrollo en una institución educativa y/o fundación" },
                new Actividad { Id = 43, Numero = 43, AreaId = 1, TextoActividad = "Rediseñar y decorar espacios físicos en viviendas, oficinas y locales comerciales" },
                new Actividad { Id = 44, Numero = 44, AreaId = 3, TextoActividad = "Administrar una empresa de turismo y/o agencias de viaje" },
                new Actividad { Id = 45, Numero = 45, AreaId = 5, TextoActividad = "Aplicar métodos alternativos a la medicina tradicional para atender personas con dolencias de diversa índole" },
                new Actividad { Id = 46, Numero = 46, AreaId = 1, TextoActividad = "Diseñar ropa para niños, jóvenes y adultos" },
                new Actividad { Id = 47, Numero = 47, AreaId = 5, TextoActividad = "Investigar organismos vivos para elaborar vacunas" },
                new Actividad { Id = 48, Numero = 48, AreaId = 4, TextoActividad = "Manejar y/o dar mantenimiento a dispositivos/aparatos tecnológicos en aviones, barcos, radares, etcétera" },
                new Actividad { Id = 49, Numero = 49, AreaId = 2, TextoActividad = "Estudiar idiomas extranjeros -actuales y antiguos- para hacer traducción" },
                new Actividad { Id = 50, Numero = 50, AreaId = 1, TextoActividad = "Restaurar piezas y obras de arte" },
                new Actividad { Id = 51, Numero = 51, AreaId = 4, TextoActividad = "Revisar y dar mantenimiento a artefactos eléctricos, electrónicos y computadoras" },
                new Actividad { Id = 52, Numero = 52, AreaId = 2, TextoActividad = "Enseñar a niños de 0 a 5 años" },
                new Actividad { Id = 53, Numero = 53, AreaId = 3, TextoActividad = "Investigar y/o sondear nuevos mercados" },
                new Actividad { Id = 54, Numero = 54, AreaId = 5, TextoActividad = "Atender la salud dental de las personas" },
                new Actividad { Id = 55, Numero = 55, AreaId = 2, TextoActividad = "Tratar a niños, jóvenes y adultos con problemas psicológicos" },
                new Actividad { Id = 56, Numero = 56, AreaId = 3, TextoActividad = "Crear estrategias de promoción y venta de nuevos productos ecuatorianos en el mercado internacional" },
                new Actividad { Id = 57, Numero = 57, AreaId = 5, TextoActividad = "Planificar y recomendar dietas para personas diabéticas y/o con sobrepeso" },
                new Actividad { Id = 58, Numero = 58, AreaId = 4, TextoActividad = "Trabajar en una empresa petrolera en un cargo técnico como control de la producción" },
                new Actividad { Id = 59, Numero = 59, AreaId = 3, TextoActividad = "Administrar una empresa (familiar, privada o pública)" },
                new Actividad { Id = 60, Numero = 60, AreaId = 4, TextoActividad = "Tener un taller de reparación y mantenimiento de carros, tractores, etcétera" },
                new Actividad { Id = 61, Numero = 61, AreaId = 4, TextoActividad = "Ejecutar proyectos de extracción minera y metalúrgica" },
                new Actividad { Id = 62, Numero = 62, AreaId = 3, TextoActividad = "Asistir a directivos de multinacionales con manejo de varios idiomas" },
                new Actividad { Id = 63, Numero = 63, AreaId = 2, TextoActividad = "Diseñar programas educativos para niños con discapacidad" },
                new Actividad { Id = 64, Numero = 64, AreaId = 4, TextoActividad = "Aplicar conocimientos de estadística en investigaciones en diversas áreas (social, administrativa, salud, etcétera)" },
                new Actividad { Id = 65, Numero = 65, AreaId = 1, TextoActividad = "Fotografiar hechos históricos, lugares significativos, rostros, paisajes para el área publicitaria, artística, periodística y social" },
                new Actividad { Id = 66, Numero = 66, AreaId = 2, TextoActividad = "Trabajar en museos y bibliotecas nacionales e internacionales" },
                new Actividad { Id = 67, Numero = 67, AreaId = 1, TextoActividad = "Ser parte de un grupo de teatro" },
                new Actividad { Id = 68, Numero = 68, AreaId = 1, TextoActividad = "Producir cortometrajes, spots publicitarios, programas educativos, de ficción, etcétera" },
                new Actividad { Id = 69, Numero = 69, AreaId = 5, TextoActividad = "Estudiar la influencia entre las corrientes marinas y el clima y sus consecuencias ecológicas" },
                new Actividad { Id = 70, Numero = 70, AreaId = 2, TextoActividad = "Conocer las distintas religiones, su filosofía y transmitirlas a la comunidad en general" },
                new Actividad { Id = 71, Numero = 71, AreaId = 3, TextoActividad = "Asesorar a inversionistas en la compra de bienes/acciones en mercados nacionales e internacionales" },
                new Actividad { Id = 72, Numero = 72, AreaId = 2, TextoActividad = "Estudiar grupos étnicos, sus costumbres, tradiciones, cultura y compartir sus vivencias" },
                new Actividad { Id = 73, Numero = 73, AreaId = 4, TextoActividad = "Explorar el espacio sideral, los planetas, sus características y componentes" },
                new Actividad { Id = 74, Numero = 74, AreaId = 5, TextoActividad = "Mejorar la imagen facial y corporal de las personas aplicando diferentes técnicas" },
                new Actividad { Id = 75, Numero = 75, AreaId = 1, TextoActividad = "Decorar jardines de casas y parques públicos" },
                new Actividad { Id = 76, Numero = 76, AreaId = 5, TextoActividad = "Administrar y renovar menúes de comidas en un hotel o restaurante" },
                new Actividad { Id = 77, Numero = 77, AreaId = 1, TextoActividad = "Trabajar como presentador de televisión, locutor de radio y televisión, animador de programas culturales y concursos" },
                new Actividad { Id = 78, Numero = 78, AreaId = 2, TextoActividad = "Diseñar y ejecutar programas de turismo" },
                new Actividad { Id = 79, Numero = 79, AreaId = 4, TextoActividad = "Administrar y ordenar (planificar) adecuadamente la ocupación del espacio físico de ciudades, países, etc., utilizando imágenes de satélite, mapas" },
                new Actividad { Id = 80, Numero = 80, AreaId = 3, TextoActividad = "Organizar, planificar y administrar centros educativos" }
            );
        }
    }
}
