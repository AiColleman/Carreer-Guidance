using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace IntegrationTests
{
    [TestClass]
    public class DatabaseInitializationTests
    {
        [TestMethod]
        public async Task TC03_BaseDeDatos_DebeContener5AreasY80Actividades()
        {
            // Arrange: Usar la conexión del contenedor SQL Server levantado por TestcontainersSetup
            var connectionString = TestcontainersSetup.ConnectionString;
            Assert.IsNotNull(connectionString, "La cadena de conexión del contenedor no debe ser nula.");

            var options = new DbContextOptionsBuilder<VocationalDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new VocationalDbContext(options);
            await context.Database.EnsureCreatedAsync();

            // Act
            var cantidadAreas = await context.Areas.CountAsync();
            var cantidadActividades = await context.Actividades.CountAsync();

            // Assert
            Assert.AreEqual(5, cantidadAreas,
                "La base de datos debe contener exactamente 5 áreas vocacionales.");
            Assert.AreEqual(80, cantidadActividades,
                "La base de datos debe contener exactamente 80 actividades.");
        }
    }
}
