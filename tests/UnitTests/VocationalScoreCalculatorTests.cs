using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Entities;
using Core.Models;
using Core.Services;

namespace UnitTests
{
    [TestClass]
    public class VocationalScoreCalculatorTests
    {
        private readonly VocationalScoreCalculator _calculator = new();

        private static List<Area> CrearAreas()
        {
            return new List<Area>
            {
                new Area { Id = 1, Nombre = "Arte y Creatividad" },
                new Area { Id = 2, Nombre = "Ciencias Sociales" },
                new Area { Id = 3, Nombre = "Económica, Administrativa y Financiera" },
                new Area { Id = 4, Nombre = "Ciencia y Tecnología" },
                new Area { Id = 5, Nombre = "Ciencias Ecológicas, Biológicas y de la Salud" }
            };
        }

        /// <summary>
        /// Crea un bloque de respuestas para un área determinada.
        /// </summary>
        private static List<Respuesta> CrearRespuestas(
            int areaId, int cantidad, int cantidadTrue, ref int actividadIdCounter)
        {
            var respuestas = new List<Respuesta>();
            for (int i = 0; i < cantidad; i++)
            {
                var actId = actividadIdCounter++;
                respuestas.Add(new Respuesta
                {
                    Id = actId,
                    ActividadId = actId,
                    MeInteresa = i < cantidadTrue,
                    Actividad = new Actividad
                    {
                        Id = actId,
                        Numero = actId,
                        AreaId = areaId,
                        TextoActividad = $"Actividad de prueba {actId}"
                    }
                });
            }
            return respuestas;
        }

        [TestMethod]
        public void TC01_AreaConMasPuntos_DebeSerPrimeraOpcion()
        {
            // Arrange: 80 respuestas. 15 "Me interesa" para Área 1, < 10 para el resto.
            var areas = CrearAreas();
            int counter = 1;
            var respuestas = new List<Respuesta>();
            respuestas.AddRange(CrearRespuestas(areaId: 1, cantidad: 16, cantidadTrue: 15, ref counter));
            respuestas.AddRange(CrearRespuestas(areaId: 2, cantidad: 16, cantidadTrue: 8,  ref counter));
            respuestas.AddRange(CrearRespuestas(areaId: 3, cantidad: 16, cantidadTrue: 7,  ref counter));
            respuestas.AddRange(CrearRespuestas(areaId: 4, cantidad: 16, cantidadTrue: 6,  ref counter));
            respuestas.AddRange(CrearRespuestas(areaId: 5, cantidad: 16, cantidadTrue: 5,  ref counter));

            Assert.AreEqual(80, respuestas.Count, "Deben existir exactamente 80 respuestas.");

            // Act
            var resultado = _calculator.CalcularAreasGanadoras(respuestas, areas);

            // Assert
            Assert.IsTrue(resultado.Count >= 2, "Debe devolver al menos 2 áreas.");
            Assert.AreEqual(1, resultado[0].AreaId, "El Área 1 debe ser la primera opción.");
            Assert.AreEqual(15, resultado[0].Puntos, "El Área 1 debe tener 15 puntos.");
        }

        [TestMethod]
        public void TC02_EmpateEnPrimerLugar_DebeRetornarAmbasAreasSinExcepcion()
        {
            // Arrange: 80 respuestas con empate entre Área 1 y Área 2 (10 puntos cada una).
            var areas = CrearAreas();
            int counter = 1;
            var respuestas = new List<Respuesta>();
            respuestas.AddRange(CrearRespuestas(areaId: 1, cantidad: 16, cantidadTrue: 10, ref counter));
            respuestas.AddRange(CrearRespuestas(areaId: 2, cantidad: 16, cantidadTrue: 10, ref counter));
            respuestas.AddRange(CrearRespuestas(areaId: 3, cantidad: 16, cantidadTrue: 5,  ref counter));
            respuestas.AddRange(CrearRespuestas(areaId: 4, cantidad: 16, cantidadTrue: 3,  ref counter));
            respuestas.AddRange(CrearRespuestas(areaId: 5, cantidad: 16, cantidadTrue: 2,  ref counter));

            Assert.AreEqual(80, respuestas.Count, "Deben existir exactamente 80 respuestas.");

            // Act - no debe lanzar excepciones
            var resultado = _calculator.CalcularAreasGanadoras(respuestas, areas);

            // Assert
            Assert.IsTrue(resultado.Count >= 2,
                "Debe devolver al menos 2 áreas cuando hay empate.");

            var idsGanadores = resultado.Select(r => r.AreaId).ToList();
            CollectionAssert.Contains(idsGanadores, 1,
                "El Área 1 debe estar entre las ganadoras.");
            CollectionAssert.Contains(idsGanadores, 2,
                "El Área 2 debe estar entre las ganadoras.");

            Assert.IsTrue(resultado.All(r => r.Puntos == 10),
                "Todas las áreas ganadoras empatadas deben tener 10 puntos.");
        }
    }
}
