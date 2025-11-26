using HotelListing.API.Abstract;
using HotelListing.API.Controllers;
using HotelListing.API.Data;
using HotelListing.API.DTOs;
using HotelListing.API.DTOs.HotelsDTOs;
using HotelListing.API.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DbContext confg. with DI
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<HotelListingDb>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile(typeof(MappingProfiles)));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 

//Her repository için ayrý bir scope eklemeye gerek yok çünkü biz hepsini UoW üstünden kullanacaðýz.
//Yani biz UoW'yu scope edince diðerleri de UoW içerisinde inherit edilecek.

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
    // 1. Swagger JSON dosyasýný Scalar'ýn beklediði adreste oluþturuyoruz
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "openapi/{documentName}.json";
    });
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("HotelListiningAPI")
               .WithTheme(ScalarTheme.Moon); // Mars, Moon, BluePlanet, DeepSpace vb. seçilebilir
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
 

app.Run();
