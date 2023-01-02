using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/* -------------------------------------------------
**** Add services to the container
    - order is not too important
------------------------------------------------- */

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(
    opt =>
    {
        opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);
builder.Services.AddCors();

var app = builder.Build(); // anything before this is considered our services container

/* -------------------------------------------------
**** Configure the HTTP request pipeline. (Middleware)
    - Order matters
------------------------------------------------- */

app.UseCors(
    builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200")
);

app.MapControllers();

app.Run();
