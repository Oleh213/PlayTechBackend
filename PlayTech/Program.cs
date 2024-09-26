using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PlayTech.Abstractions.AppSettings;
using PlayTech.Business;
using PlayTech.Infrastructure.Database;
using PlayTech.Infrastructure.Mediatr;
using PlayTech.Repositories;

var builder = WebApplication.CreateBuilder(args);
var appSettings = BindAppSettings(builder.Configuration);

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


var assemblies = new[]
{
    typeof(Program).Assembly, 
    typeof(BusinessServiceCollectionExtensions).Assembly,
};

builder.Services.AddMediatRInfrastructure(assemblies);
builder.Services.AddMSSqlInfrastructure(appSettings);
builder.Services.AddRepositoryInfrastructure();
builder.Services.AddBusiness();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Play Tech API");
        c.RoutePrefix = string.Empty;  
    });
}

app.UseCors(builder =>
    builder.WithOrigins()
        .SetIsOriginAllowed(origin => true)
        .AllowAnyHeader()
        .AllowCredentials()
        .AllowAnyMethod());


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

static AppSettings BindAppSettings(IConfiguration configuration)
{
    var appSettings = new AppSettings();

    try
    {
        new ConfigureFromConfigurationOptions<AppSettings>(configuration).Configure(appSettings);
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Error binding appsettings.json to AppSettings: {exception}");
        throw;
    }

    return appSettings;
}