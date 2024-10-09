using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Services;
using MSP_ProyectoMultimedia2024.Services.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICursos, CursosRepository>();
builder.Services.AddScoped<IUsuarios, UsuariosRepository>();
builder.Services.AddScoped<ICategorias, CategoriasRepository>();

builder.Services.AddDbContext<CleverlandContext>(
    options =>
    {
        //options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
        options.UseSqlServer(builder.Configuration.GetConnectionString("BD"));

    });

builder.Services.AddScoped<ICursos, CursosRepository>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
