using EntityFrameworkCore.EncryptColumn.Interfaces;
using IServices;
using IServices.Models;
using MediConnectSuiteAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContextFactory<MediConnectSuiteApiContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("MediConnectSuiteContext")));

// Add services to the container.
builder.Services.AddSingleton<IWeatherForeCast, WeatherForecastService>();
builder.Services.AddScoped<IAppointmentsService, AppointmentsService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDiagnoseRecords, DiagnoseRecordsService>();
builder.Services.AddScoped<IVitalsService, VitalsService>();
builder.Services.AddScoped<IGuestAccessService, GuestAccessService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddSingleton<IEncryptionProvider2>(new EncryptionProvider("YourEncryptionKe", "YourEncryptionKe"));


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

app.UseAuthorization();

app.MapControllers();

app.Run();
