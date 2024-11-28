using MovieSystem.Infrastructure.Presistance.Configrations;
using MovieSystem.Application.Configrations;
using MovieSystem.API.Configrations;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddAPIServices(builder.Configuration);
 

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
    //options.AddPolicy("SpecificOrigins", builder =>
    //{
    //    builder.WithOrigins("https://example.com", "https://anotherdomain.com")
    //           .AllowAnyMethod()
    //           .AllowAnyHeader();
    //});
    //options.AddPolicy("CustomPolicy", builder =>
    //{
    //    builder.WithOrigins("https://example.com")
    //           .WithMethods("GET", "POST") // Allow only GET and POST methods
    //           .WithHeaders("Content-Type", "Authorization") // Allow specific headers
    //           .AllowCredentials(); // Allow cookies or credentials
    //});
});




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
