using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testcontainers.MsSql;

namespace IntegrationTests
{
    [TestClass]
    public class TestcontainersSetup
    {
        private static MsSqlContainer _msSqlContainer;

        public static string ConnectionString => _msSqlContainer?.GetConnectionString();

        [AssemblyInitialize]
        public static async Task Initialize(TestContext context)
        {
            _msSqlContainer = new MsSqlBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .WithPassword("Strong_Password_123!")
                .Build();

            await _msSqlContainer.StartAsync();
        }

        [AssemblyCleanup]
        public static async Task Cleanup()
        {
            if (_msSqlContainer != null)
            {
                await _msSqlContainer.DisposeAsync();
            }
        }
    }
}
