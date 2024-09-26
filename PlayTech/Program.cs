using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Play Tech API",
        Version = "v1"
    });
});


var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();