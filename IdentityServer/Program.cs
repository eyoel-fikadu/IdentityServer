using IdentityServer.Persistance;
using IdentityServer.Persistance.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = "_allowedOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000");
            //policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});


DependencyInjection.AddApplicationServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


DatabaseInitializer.PopulateIdentityServer(app);


app.UseCors(allowedOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseIdentityServer();

app.Run();
