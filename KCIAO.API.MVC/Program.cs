using KCIAO.API.MVC.Infraestructure.Data.AppData;
using Microsoft.EntityFrameworkCore;
using KCIAO.API.MVC.Infraestructure.Data.Repositories;
using KCIAO.API.MVC.Application.Services;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Domain.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api KCIAO",
        Version = "v1",
        Description = "Api para cadastro de clientes e doenças",
    });
    c.EnableAnnotations();
}
    );


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api KCIAO v1");
    });
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
