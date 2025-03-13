using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => {});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
  c.SwaggerDoc("v1", new OpenApiInfo {
    Title = "MovieBox Review Site",
    Description = "Rate your favorite movies.",
    Version = "v1"
  });
});

// Application 
var app = builder.Build();

if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieBox API V1");
  });
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/reviews", () => {
  
});

app.Run();
