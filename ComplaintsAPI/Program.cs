using ComplaintsAPI.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ComplaintsDataBaseSettings>(builder.Configuration.GetSection(nameof(ComplaintsDataBaseSettings)));
builder.Services.AddSingleton<IComplaintsDataBaseSettings>(sp => sp.GetRequiredService<IOptions<ComplaintsDataBaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("ComplaintsDataBaseSettings:ConnectionString")));
builder.Services.AddScoped<IComplaintsService, ComplaintsService>();

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
