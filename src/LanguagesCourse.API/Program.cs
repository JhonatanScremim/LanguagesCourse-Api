using LanguagesCourse.Repository.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LanguagesCourse.Repository;
using LanguagesCourse.Repository.Interfaces;
using LanguagesCourse.Application;
using LanguagesCourse.Application.Interfaces;
using LanguagesCourse.Infra.Interfaces;
using LanguagesCourse.Infra.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("LanguagesCourse")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();

//Repositories
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();

builder.Services.AddScoped<IValidationHelper, ValidationHelper>();

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
