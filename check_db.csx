using System;
using Microsoft.Data.Sqlite;

var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "src/Web/vocational.db" };
using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
connection.Open();

var cmd = connection.CreateCommand();
cmd.CommandText = "SELECT COUNT(*) FROM Sesiones";
Console.WriteLine("Sesiones: " + cmd.ExecuteScalar());

cmd.CommandText = "SELECT COUNT(*) FROM Respuestas";
Console.WriteLine("Respuestas: " + cmd.ExecuteScalar());
