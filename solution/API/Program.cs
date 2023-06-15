using Domain;
using Infraestructure;
using Infraestructure.Context;
using LearningCenter.API.Mapper;
using LearningCenter.Domain.Interfaces;
using LearningCenter.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDestinationDomain, DestinationDomain>();
builder.Services.AddScoped<IDestinationInfraestructure, DestinationInfraestrcture>(); //aqui se instancias las infraestrcutures si despues se cambia es aqui donde se instancia esa nueva



//Conexion a sql

var connectionString = builder.Configuration.GetConnectionString("SuscriptionsConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(InputToModel));

builder.Services.AddDbContext<SuscriptionDBContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });



var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<SuscriptionDBContext>())
{
    context.Database.EnsureCreated();
}


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
