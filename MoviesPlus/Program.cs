using Business.Contracts.Repositories;
using Business.Contracts.Services;
using Business.Services;
using Core.Contracts.Services;
using Core.DB;
using Core.Entities;
using Core.Repositories;
using Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MoviesPlusDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Repositories
builder.Services.AddScoped<IRepositoryBase<Actor>, RepositoryBase<Actor>>();
builder.Services.AddScoped<IRepositoryBase<Movie>, RepositoryBase<Movie>>();
builder.Services.AddScoped<IRepositoryBase<ActorMovie>, RepositoryBase<ActorMovie>>();
builder.Services.AddScoped<IRepositoryBase<Genre>, RepositoryBase<Genre>>();

// Services
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IGenresService, GenresService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
