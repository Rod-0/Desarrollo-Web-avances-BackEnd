using Domain;
using Infraestructure;
using Infraestructure.Context;
using LearningCenter.API.Mapper;
using LearningCenter.Domain;
using LearningCenter.Domain.Interfaces;
using LearningCenter.Infraestructure;
using LearningCenter.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITutorialDomain, TutorialDomain>();
builder.Services.AddScoped<ITutorialInfraestructure, TutorialMySQLInfraestrcture>(); //aqui se instancias las infraestrcutures si despues se cambia es aqui donde se instancia esa nueva
builder.Services.AddScoped<IUserInfraestructure, UserInfraestructure>();
builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<IEncryptDomain, EncryptDomain>();
builder.Services.AddScoped<ITokenDomain, TokenDomain>();
builder.Services.AddScoped<IPostInfraestructure, PostInfraestructure>();



//Conexion a sql

var connectionString = builder.Configuration.GetConnectionString("learningCenterConnectionUser");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(InputToModel));

//jwt
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});


builder.Services.AddDbContext<LearningCenterDBContext>(
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
using (var context = scope.ServiceProvider.GetService<LearningCenterDBContext>())
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
