var builder = WebApplication.CreateBuilder(args);
var Cors = "Cors";

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Solo para probar las relaciones entre entidades, evitar ciclos infinitos
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: Cors,
            builder =>
            {
                builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(Cors);
app.MapControllers();
app.Run();

// Hacer Program accesible para tests de integración
public partial class Program { }

