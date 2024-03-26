using HMODTO;
using AutoMapper;
using HmoDAL;
using HmoBL;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
       
    });
});
builder.Services.AddAutoMapper(typeof(AutoMapping));

builder.Services.AddScoped<IHmoMemberDL, HmoMemberDL>();
builder.Services.AddScoped<IHmoMemberBL, HmoMemberBL>();

builder.Services.AddScoped<IManufacturerDL, ManufacturerDL>();
builder.Services.AddScoped<IManufacturerBL, ManufacturerBL>();
builder.Services.AddScoped<ISickDL, SickDL>();
builder.Services.AddScoped<ISickBL, SickBL>();
builder.Services.AddScoped<IVaccinatedDL, VaccinatedDL>();
builder.Services.AddScoped<IVaccinatedBL, VaccinatedBL>();

var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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
