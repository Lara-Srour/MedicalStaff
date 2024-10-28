//using MedicalStaffAPI.Models;

using Microsoft.EntityFrameworkCore;
using MedicalStaff.Infrastructure;
using FluentValidation.AspNetCore;
using MedicalStaff.Application.DtoValidators;

using FluentValidation;
using MedicalStaff.Infrastructure.Repositories;
using MedicalStaff.Application.Interfaces;
using System.Reflection;

using MediatR;
using MedicalStaff.Application.Handlers.Departments;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddDbContext<MedicalStaffContext>(opt => opt.UseInMemoryDatabase("MedicalStaff"));
// Configure the DbContext to use SQLite
builder.Services.AddDbContext<MedicalStaffDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("MedicalStaffDatabase")));

// Register AutoValidation and Client-Side Adapters
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Register all FluentValidators
builder.Services.AddValidatorsFromAssemblyContaining<DepartmentValidator>();


// Register your repositories
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<INurseRepository, NurseRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

// Register MediatR for the entire assembly
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(AddDepartmentHandler).Assembly);
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

app.UseAuthorization();

app.MapControllers();

app.Run();
