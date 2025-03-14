using Microsoft.OpenApi.Models;
using MovieBox.DB;
using MovieBox.OMDb;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

using HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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

var omdbApiKey = System.Environment.GetEnvironmentVariable("OMDB_API_KEY");
if (string.IsNullOrEmpty(omdbApiKey)) {
  Console.WriteLine("OMDB_API_KEY environment variable not set.");
  Environment.Exit(1);
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/search", async (HttpContext context, string title) => {
  var response = await client.GetAsync($"http://www.omdbapi.com/?apikey={omdbApiKey}&s={title}");
  if (response == null) {
    return "No movies found.";
  } else {
    context.Response.Headers["Content-Type"] = "application/json";
    return await response.Content.ReadAsStringAsync();
  }
});

app.MapGet("/reviews", () => {
  
});

app.Run();
