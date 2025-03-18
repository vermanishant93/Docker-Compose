using ColourAPI.Models;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Colour API", Version = "v1" });
});

var server = builder.Configuration["DBServer"] ?? "localhost";
var port = builder.Configuration["DBPort"] ?? "1433";
var user = builder.Configuration["DBUser"] ?? "SA";
var password = builder.Configuration["DBPassword"] ?? "reallyStrongPwd123";
var database = builder.Configuration["Database"] ?? "Practice";

builder.Services.AddDbContext<ColourContext>(options =>
    options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID={user};Password={password};TrustServerCertificate=true"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Colour API v1"));
}

app.UseHttpsRedirection();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();

PrepDb.PrepPopulation(app);

app.Run();