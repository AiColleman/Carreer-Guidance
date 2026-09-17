using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Core.Entities;
using Core.Services;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        private readonly VocationalDbContext _context;

        public TestController(VocationalDbContext context)
        {
            _context = context;
        }

        // GET /Test/Start
        [HttpGet]
        public async Task<IActionResult> Start()
        {
            // Crear nueva sesión
            var sesion = new Sesion
            {
                Id = Guid.NewGuid(),
                FechaCreacion = DateTime.Now
            };
            _context.Sesiones.Add(sesion);
            await _context.SaveChangesAsync();

            // Cargar actividades mezcladas aleatoriamente
            var actividades = await _context.Actividades
                .Include(a => a.Area)
                .ToListAsync();

            actividades = actividades.OrderBy(a => Guid.NewGuid()).ToList();

            ViewBag.SesionId = sesion.Id;
            return View(actividades);
        }

        // POST /Test/Swipe
        [HttpPost]
        public async Task<IActionResult> Swipe([FromBody] SwipeRequest request)
        {
            if (request == null)
                return BadRequest();

            var respuesta = new Respuesta
            {
                SesionId = request.SesionId,
                ActividadId = request.ActividadId,
                MeInteresa = request.MeInteresa
            };

            _context.Respuestas.Add(respuesta);
            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }

        // GET /Test/Results/{sesionId}
        [HttpGet]
        public async Task<IActionResult> Results(Guid sesionId)
        {
            var respuestas = await _context.Respuestas
                .Where(r => r.SesionId == sesionId)
                .Include(r => r.Actividad)
                .ToListAsync();

            var areas = await _context.Areas.ToListAsync();

            var calculator = new VocationalScoreCalculator();
            var resultados = calculator.CalcularAreasGanadoras(respuestas, areas);

            ViewBag.SesionId = sesionId;
            ViewBag.TotalRespuestas = respuestas.Count;
            return View(resultados);
        }
    }

    public class SwipeRequest
    {
        public Guid SesionId { get; set; }
        public int ActividadId { get; set; }
        public bool MeInteresa { get; set; }
    }
}
