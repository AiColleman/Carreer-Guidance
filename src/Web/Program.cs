using Microsoft.EntityFrameworkCore;
using Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<VocationalDbContext>(options =>
{
    var conn = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(conn ?? "Host=localhost;Database=postgres;Username=postgres;Password=postgres");
});

var app = builder.Build();

// Ensure database is created with seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<VocationalDbContext>();
    bool isHealthy = false;
    try 
    {
        // Try to query the Respuestas table to see if the full schema exists
        db.Respuestas.FirstOrDefault();
        isHealthy = true;
    }
    catch
    {
        // Table missing or schema broken
    }

    if (!isHealthy)
    {
        Console.WriteLine("Schema incomplete or broken. Recreating from scratch...");
        try 
        {
            db.Database.ExecuteSqlRaw("DROP SCHEMA public CASCADE; CREATE SCHEMA public; GRANT ALL ON SCHEMA public TO postgres; GRANT ALL ON SCHEMA public TO public;");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error dropping schema: " + ex.Message);
        }
        
        // This will create all tables and run the seed data
        db.Database.EnsureCreated();
    }
}

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();

// Render provides the PORT environment variable. We should listen on it.
var port = Environment.GetEnvironmentVariable("PORT") ?? "80";
app.Urls.Add($"http://0.0.0.0:{port}");

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Test}/{action=Start}/{id?}")
    .WithStaticAssets();


app.Run();
