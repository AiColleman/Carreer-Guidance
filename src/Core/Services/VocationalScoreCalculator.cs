using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Models;

namespace Core.Services
{
    public class VocationalScoreCalculator
    {
        private static readonly Dictionary<int, string> ProfesionesPorArea = new()
        {
            { 1, "Diseño Gráfico, Diseño y Decoración de Interiores, Diseño de Jardines, Diseño de Modas, Diseño de Joyas, Artes Plásticas (Pintura, Escultura, Danza, Teatro, Artesanía, Cerámica), Dibujo Publicitario, Restauración y Museología, Modelaje, Fotografía, Fotografía Digital, Gestión Gráfica y Publicitaria, Locución y Publicidad, Actuación, Camarografía, Arte Industrial, Producción Audiovisual y Multimedia, Comunicación y Producción en Radio y Televisión, Diseño del Paisaje, Cine y Video, Comunicación Escénica para televisión." },
            { 2, "Psicología en general, Trabajo Social, Idiomas, Educación Internacional, Historia y Geografía, Periodismo, Periodismo Digital, Derecho, Ciencias Políticas, Sociología, Antropología, Arqueología, Gestión Social y Desarrollo, Consejería Familiar, Comunicación y Publicidad, Administración Educativa, Educación Especial, Psicopedagogía, Estimulación Temprana, Traducción Simultánea, Lingüística, Educación de Párvulos, Bibliotecología, Museología, Relaciones Internacionales y Diplomacia, Comunicación Social con mención en Marketing y Gestión de Empresas, Redacción Creativa y Publicitaria, Relaciones Públicas y Comunicación Organizacional, Hotelería y Turismo, Teología, Institución Sacerdotal." },
            { 3, "Administración de Empresas, Contabilidad, Auditoría, Ventas, Marketing Estratégico, Gestión y Negocios Internacionales, Gestión Empresarial, Gestión Financiera, Ingeniería Comercial, Comercio Exterior, Banca y Finanzas, Gestión de Recursos Humanos, Comunicaciones Integradas en Marketing, Administración de Empresas Ecoturísticas y de Hospitalidad, Ciencias Económicas y Financieras, Administración y Ciencias Políticas, Ciencias Empresariales, Comercio Electrónico, Emprendedores, Gestión de Organismos Públicos (Municipios, Ministerios, etcétera), Gestión de Centros Educativos." },
            { 4, "Ingeniería en Sistemas Computacionales, Geología, Ingeniería Civil, Arquitectura, Electrónica, Telemática, Telecomunicaciones, Ingeniería Mecatrónica (Robótica), Imagen y Sonido, Minas, Petróleo y Metalurgia, Ingeniería Mecánica, Ingeniería Industrial, Física, Matemáticas Aplicadas, Ingeniería en Estadística, Ingeniería Automotriz, Biotecnología Ambiental, Ingeniería Geográfica, Carreras Militares (Marina, Aviación, Ejército), Ingeniería en Costas y Obras Portuarias, Estadística Informática, Programación y Desarrollo de Sistemas, Tecnología en Informática Educativa, Astronomía, Ingeniería en Ciencias Geográficas y Desarrollo Sustentable." },
            { 5, "Biología, Bioquímica, Farmacia, Biología Marina, Bioanálisis, Biotecnología, Ciencias Ambientales, Zootecnia, Veterinaria, Nutrición y Estética, Cosmetología, Dietética y Estética, Medicina, Obstetricia, Urgencias Médicas, Odontología, Enfermería, Tecnología, Oceanografía y Ciencias Ambientales, Médica, Agronomía, Horticultura y Fruticultura, Ingeniería de Alimentos, Gastronomía, Chef, Cultura Física, Deportes y Rehabilitación, Gestión Ambiental, Ingeniería Ambiental, Optometría, Homeopatía, Reflexología." }
        };

        public List<VocationalResult> CalcularAreasGanadoras(
            IEnumerable<Respuesta> respuestas,
            IEnumerable<Area> areas)
        {
            var puntajes = areas.ToDictionary(a => a.Id, a => new VocationalResult
            {
                AreaId = a.Id,
                NombreArea = a.Nombre,
                Puntos = 0,
                Profesiones = ProfesionesPorArea.GetValueOrDefault(a.Id, "")
            });

            foreach (var respuesta in respuestas)
            {
                if (respuesta.MeInteresa && puntajes.ContainsKey(respuesta.Actividad.AreaId))
                {
                    puntajes[respuesta.Actividad.AreaId].Puntos++;
                }
            }

            var resultadosOrdenados = puntajes.Values
                .OrderByDescending(r => r.Puntos)
                .ToList();

            if (resultadosOrdenados.Count < 2)
                return resultadosOrdenados;

            var primerPuntaje = resultadosOrdenados[0].Puntos;
            var empatadosPrimero = resultadosOrdenados
                .Where(r => r.Puntos == primerPuntaje)
                .ToList();

            // Si hay empate en primer lugar, devolver todas las áreas empatadas (BR-04 + TC-02)
            if (empatadosPrimero.Count >= 2)
                return empatadosPrimero;

            // Sin empate en primero: devolver primera + segunda(s) opción
            var segundoPuntaje = resultadosOrdenados[1].Puntos;
            var resultado = new List<VocationalResult> { resultadosOrdenados[0] };
            resultado.AddRange(resultadosOrdenados.Where(r => r.Puntos == segundoPuntaje));
            return resultado;
        }
    }
}
