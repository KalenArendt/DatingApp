using API.Extentions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

/* -------------------------------------------------
**** Add services to the container
    - order is not too important
------------------------------------------------- */
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

WebApplication app = builder.Build(); // anything before this is considered our services container

/* -------------------------------------------------
**** Configure the HTTP request pipeline. (Middleware)
    - Order matters
------------------------------------------------- */

app.UseCors(
    builder
    => builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("https://localhost:4200")
);

app.MapControllers();

app.UseAuthentication();    // do you have a valid token                        -- do you have valid id?
app.UseAuthorization();     // what are you allowed to do with the said token   -- does your id say you're 18+? 

app.Run();
