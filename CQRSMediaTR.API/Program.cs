using CQRSMediaTR.API.Data;
using CQRSMediaTR.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();  
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

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

var supportedCultures = new[] { "en-US", "en", "id", };
var localizationOptions =
    new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.Run();
