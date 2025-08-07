using Microsoft.EntityFrameworkCore;
using My.OfferApp.Bll;
using My.OfferApp.Dal.Contexts;
using My.OfferApp.Web.StartupConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        connectionString,
        sqlServerBuilder =>
        {
            sqlServerBuilder.CommandTimeout(180);
        }
    )
);

builder.Services.AddBll();

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.InitializeDatabase();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
