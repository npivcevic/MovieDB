using Microsoft.EntityFrameworkCore;
using WebApplication1.DataContextLayer;
using WebApplication1.Repositories;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MoviesService, MoviesService>();
builder.Services.AddScoped<MoviesRepository, MoviesRepository>();
builder.Services.AddScoped<ActorsRepository, ActorsRepository>();
builder.Services.AddScoped<ActorsService, ActorsService>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=movieDb;Trusted_Connection=True;TrustServerCertificate=True;");
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

app.UseStaticFiles();
app.UseDefaultFiles("/test.html");

app.Run();
