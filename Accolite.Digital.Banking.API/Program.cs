using Accolite.Digital.Banking.Common;
using Accolite.Digital.Banking.Common.Services.Interface;
using Accolite.Digital.Banking.API.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
CommonStartup.ConfigureServices(builder.Services);
builder.InjectServices();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
