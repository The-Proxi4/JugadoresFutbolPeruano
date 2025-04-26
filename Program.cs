using JugadoresFutbolPeruano.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// REGISTROS DE SERVICIOS
builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews(); // <-- Esta es la clave 🔑

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// CONFIGURACIÓN DEL PIPELINE
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Player}/{action=Create}/{id?}")
    .WithStaticAssets();

app.Run();
