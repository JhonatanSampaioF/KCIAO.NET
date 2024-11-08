using KCIAO.API.MVC.Infraestructure.Data.AppData;
using Microsoft.EntityFrameworkCore;
using KCIAO.API.MVC.Infraestructure.Data.Repositories;
using KCIAO.API.MVC.Application.Services;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => {

    options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));

});

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClienteApplicationService, ClienteApplicationService>();

builder.Services.AddTransient<IDoencaRepository, DoencaRepository>();
builder.Services.AddTransient<IDoencaApplicationService, DoencaApplicationService>();

builder.Services.AddTransient<IConsultaRepository, ConsultaRepository>();
builder.Services.AddTransient<IConsultaApplicationService, ConsultaApplicationService>();

builder.Services.AddTransient<IEventoRepository, EventoRepository>();
builder.Services.AddTransient<IEventoApplicationService, EventoApplicationService>();

builder.Services.AddTransient<IClienteDoencaRepository, ClienteDoencaRepository>();
builder.Services.AddTransient<IClienteDoencaApplicationService, ClienteDoencaApplicationService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
