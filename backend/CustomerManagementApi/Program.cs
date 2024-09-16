using AutoMapper;
using CustomerManagementApi.Data;
using Microsoft.EntityFrameworkCore;
using CustomerManagementApi.Repositories;
using CustomerManagementApi.Repositories.Interfaces;
using CustomerManagementApi.Middlewares;
using CustomerManagementApi.Services.Interfaces;
using CustomerManagementApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add services to the container.
builder.Services.AddControllers();

// Configure Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Registrar serviços
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
