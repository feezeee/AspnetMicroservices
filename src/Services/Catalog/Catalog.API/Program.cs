using Catalog.API.AppSettingModels;
using Catalog.API.Data;
using Catalog.API.Finders;
using Catalog.API.Finders.Contracts;
using Catalog.API.Repositories;
using Catalog.API.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbConfiguration>(builder.Configuration.GetSection("DatabaseSettings"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductFinder, ProductFinder>();



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
