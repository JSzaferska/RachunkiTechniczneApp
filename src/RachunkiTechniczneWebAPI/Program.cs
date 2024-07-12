
using RachunkiTechniczneWebApi.Dal;
using RachunkiTechniczneWebApi.Interfaces;
using RachunkiTechniczneWebApi.Models;
using RachunkiTechniczneWebApi.Repositories;
using RachunkiTechniczneWebApi.Services;


//using RachunkiTechniczneWebApi.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
  //  .ReadFrom.Configuration(hostingContext.Configuration));

builder.Services.AddSingleton<DapperContext>();
//builder.Services.AddScoped<SearchService>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IContractService, ContractService > ();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
