using HotelListing.API.Controllers;
using HotelListing.API.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DbContext confg. with DI
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<HotelListingDb>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddControllers().AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        // Ýliþkili tablolarýn eager loading ile verilerini çekerken veri json formatýnda gelir (Api)
        //Biz ise bu veriyi json formatýnda iken kullanamayýz ve hata verir. Bu kod parçasý bunu engeller.
        //JSON Deserialize edilirken entitylerin içindeki hotel için country, country için list<hotel>
        //içerisine girip sonsuz döngü yaratýr.
        //1. Hotel'de country var country'de list<hotel> var bunun içinde 1. hotel var...
        //"Eðer bir nesneyi daha önce yazdýysan ve tekrar karþýna çýkarsa
        //(örneðin Ülke -> Otel -> Tekrar Ayný Ülke),
        //sakýn tekrar içine girme. Orada dur ve o iliþkiyi null geç veya yoksay."
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
