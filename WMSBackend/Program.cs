var builder = WebApplication.CreateBuilder(args);

// Nur Controller hinzuf�gen (f�r API-Endpunkte)
builder.Services.AddControllers();

var app = builder.Build();

// API-Endpunkte registrieren
app.MapControllers();

app.Run();
