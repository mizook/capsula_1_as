using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar servicios de DbContext para ambas bases de datos
builder.Services.AddDbContext<FirstDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres1")));
builder.Services.AddDbContext<SecondDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres2")));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();