using IdentityServer.Persistance;
using IdentityServer.Persistance.DatabaseContext;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


DependencyInjection.AddApplicationServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


DatabaseInitializer.PopulateIdentityServer(app);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseIdentityServer();

app.Run();
