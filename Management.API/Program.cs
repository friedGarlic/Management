using Management.Application;
using Management.Infrastructure;
using Management.Persistence;
using Microsoft.OpenApi.Models;
using System.Reflection;

//
var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureInfrastructureService(builder.Configuration);

//builder.Services.ConfigureApplicationService();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

//
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title=" Management API",Version="v1"});
});

builder.Services.AddCors(o =>
    {
        o.AddPolicy(
            "CorsPolicy",
            builder => builder.AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
