using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarWarsFFGBookAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using StarWarsFFGBookAPI.Services;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

var connectionString = Environment.GetEnvironmentVariable("SWFFGCONNECTION");


builder.Services.AddDbContext<DataContext>(x =>
{
    x.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
});

builder.Services.AddTransient<IBookService, BookService>();

builder.Build().Run();
