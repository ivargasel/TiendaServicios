using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.ShoppingCart.Application;
using TiendaServicios.Api.ShoppingCart.Persistence;
using TiendaServicios.Api.ShoppingCart.RemoteServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ShoppingCartContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddTransient<IActionsApp, ActionsApp>();
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddHttpClient("Books", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Books"]);
});
builder.Services.AddHttpClient("Authors", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Authors"]);
});

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
