using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using v123Vendas.Aplicacao.Contratos;
using v123Vendas.Aplicacao.Services;
using v123Vendas.Data.Contexto;
using v123Vendas.Data.Contratos;
using v123Vendas.Data.Implementacao;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("DefaultConnection");

//Serilog

builder.Services.AddControllers();


Log.Logger = new LoggerConfiguration()    
    .WriteTo.File("../Logs/123Vendas.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                                   Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                   );



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IVendaPersistencia, VendaPersistencia>();
builder.Services.AddScoped<IGeralPersistencia, GeralPersistencia>();

builder.Services.AddDbContext<VendasDBContext>(options =>
                   options.UseSqlServer(conString));



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "123Vendas.Api", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
