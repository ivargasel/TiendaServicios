using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using TiendaServicios.Api.Gateway.InterfaceRemote;
using TiendaServicios.Api.Gateway.MsgHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOcelot().AddDelegatingHandler<BookHandler>();
builder.Services.AddHttpClient("AuthorService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Author"]);
});
builder.Services.AddSingleton<IAuthorService, AuthorService>();
builder.Configuration.AddJsonFile($"ocelot.json");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();

app.Run();