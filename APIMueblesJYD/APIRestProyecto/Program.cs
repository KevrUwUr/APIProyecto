using Contracts;
using APIRestProyecto.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using NLog;
using Entities.Models;
using Repository;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Proyect.Presentation.AssemblyReference).Assembly);

// Add services to the container.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
} else
{
    app.UseHsts();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.Use(async (context, next) =>
{
    Console.WriteLine($"Logica antes de ejecutar el siguiente delegado en el metodo use");
    await next.Invoke();
    Console.WriteLine($"Logica despues de ejecutar el delegado en el metodo use");
});

app.Map("/usingmapbranch", builder =>
{
    builder.Use(async (context, next) =>
    {
        Console.WriteLine("Map branch Logica antes de ejecutar el siguiente delegado en el metodo use");
        await next.Invoke();
        Console.WriteLine("Map branch Logica despues de ejecutar el siguiente delegado en el metodo use");
    });
    builder.Run(async context =>
    {
        Console.WriteLine($"Map branch Respuesta al cliente en el metodo Run");
        await context.Response.WriteAsync("Bienvenido al MapBranch");
    });
});

app.MapWhen(context => context.Request.Query.ContainsKey("testquerystring"), builder =>
    {
        builder.Run(async context =>
    {
        await context.Response.WriteAsync("Bienvenido a la rama del MapWhen");
    });
});

app.Run(async context =>
{
    Console.WriteLine($"Escribiendo la respuesta al cliente desde el metodo Run");
    await context.Response.WriteAsync("Bienvenido al componente delñ Middleware");
});

app.MapControllers();

app.Run();
