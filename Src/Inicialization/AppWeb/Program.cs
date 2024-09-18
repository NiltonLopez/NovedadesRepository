using Microsoft.EntityFrameworkCore;
using Novedades.AppWeb.AutoMapper;
using Novedades.BLL.Interfaces;
using Novedades.BLL.Service;
using Novedades.DAL.Interfaces;
using Novedades.DAL.SqlServer.DataContext;
using Novedades.DAL.SqlServer.Mappers;
using Novedades.DAL.SqlServer.Repositories;
using Novedades.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Agregación del contexto de base de datos por medio de la cadena SQL
builder.Services.AddDbContext<WebContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});
#endregion


#region Inyección de dependencias de recurso para mantener datos en caché y cookies del navegador
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
#endregion


#region Inyección de dependencias del AutoMapper
builder.Services.AddAutoMapper(typeof(ProfileVM));
builder.Services.AddAutoMapper(typeof(ProfileSQL));
#endregion


#region Inyección de dependencias de la capa de lógica de negocio (BLL)
builder.Services.AddScoped<INovedadService<NovedadValor>, NovedadValorService>();
builder.Services.AddScoped<INovedadService<NovedadHoras>, NovedadHoraService>();
builder.Services.AddScoped<INovedadService<NovedadFechas>, NovedadFechaService>();
builder.Services.AddScoped<IConceptoService, ConceptoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<ICalendarioService, CalendarioService>();
#endregion


#region Inyección de dependencias de la capa de acceso a datos (DAL)
builder.Services.AddScoped<INovedadValorRepository, NovedadesValorRepository>();
builder.Services.AddScoped<INovedadHorasRepository, NovedadesHorasRepository>();
builder.Services.AddScoped<INovedadFechasRepository, NovedadesFechasRepository>();
builder.Services.AddScoped<IConceptoRepository, ConceptoRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<ICalendarioRepository, CalendarioRepository>();
#endregion


#region Configuración de session y cookies
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

