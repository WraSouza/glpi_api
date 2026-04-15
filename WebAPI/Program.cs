using Application.IApplications.GetAllDevices;
using Application.IApplications.GetDeviceById;
using Application.IApplications.GetTicketId;
using Application.IApplications.UpdateTicket;
using Application.Services;
using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Helper;
using Infrastructure.Repository;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<GLPILogin>(builder.Configuration.GetSection("LoginGLPI"));


builder.Services.AddSingleton<IDeviceRepository, DeviceRepository>();
builder.Services.AddSingleton<IGetAllDevices,GetAllDevices>();
builder.Services.AddSingleton<IGetDeviceById, GetDeviceById>();
builder.Services.AddSingleton<IUpdateTicket, UpdateTicketService>();
builder.Services.AddSingleton<IScreenShotRepository, UpdateTicketRepository>();
builder.Services.AddSingleton<IGetIdTicket, GetTicketIdService>();
builder.Services.AddSingleton<IGetTicketId,GetTicketId>();
builder.Services.AddSingleton<LoginHelper>();

builder.Services.AddMemoryCache();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
