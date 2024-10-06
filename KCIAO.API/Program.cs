using KCIAO.API.Application.Interfaces;
using KCIAO.API.Application.Services;
using KCIAO.API.Domain.Interfaces;
using KCIAO.API.Infrastructure.Data.AppData;
using KCIAO.API.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationContext>(options => {

    options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));

});

builder.Services.AddTransient<IDoencaRepository, DoencaRepository>();
builder.Services.AddTransient<IDoencaApplicationService, DoencaApplicationService>();

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClienteApplicationService, ClienteApplicationService>();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
