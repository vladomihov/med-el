using MedEl.Domain.Services;
using MedEl.Infrastructure.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMedElServices(builder.Configuration, options => options
    .AddCarFactory<HondaCarFactory>(HondaCarFactory.BrandName)
    .AddCarFactory<ToyotaCarFactory>(ToyotaCarFactory.BrandName)
    .AddMotorcycleFactory<HondaMotorcycleFactory>(HondaMotorcycleFactory.BrandName)
    .AddMotorcycleFactory<KTMMotorcycleFactory>(KTMMotorcycleFactory.BrandName));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc(
    "v1",
    new OpenApiInfo
    {
        Title = "MED-EL Web API",
        Version = "v1",
        Description = "The MED-EL Service Web API"
    }));

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

// Logging
builder.Logging.ClearProviders();
builder.Host.UseSerilog((hostContext, services, configuration) => configuration.ReadFrom.Configuration(builder.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();

app.Run();