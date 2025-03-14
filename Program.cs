using Microsoft.OpenApi.Models;
using MovieBox.DB;
using MovieBox.OMDb;
using MovieBox.Types;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

await using var db = new MovieReviewContext();

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



app.MapGet("/api/movies/search", async (HttpContext context, string title) => {
  Console.WriteLine($"Searching for {title}");
  var response = await client.GetFromJsonAsync<OmdbSearch>($"http://www.omdbapi.com/?apikey={omdbApiKey}&s={title}");
  // var response = await client.GetStringAsync($"http://www.omdbapi.com/?apikey={omdbApiKey}&s={title}");
  
  response.Search.ForEach(Console.WriteLine);
  var results = new MovieSearchResponse();
  context.Response.ContentType = "application/json";
  results.movies = response.Search;
  return JsonSerializer.Serialize(results);
});

app.MapGet("/api/movies/{id}", async (HttpContext context, string id) => {
  var response = await client.GetAsync($"http://www.omdbapi.com/?apikey={omdbApiKey}&i={id}");
  context.Response.ContentType = "application/json";
  if (response == null) {
    return "No movie found.";
  } else {
    return await response.Content.ReadAsStringAsync();
  }
});

app.MapGet("/api/reviews", async (HttpContext context) => {
  context.Response.ContentType = "application/json";
  var results =
    from review in await db.MovieReview.ToListAsync()
    select review;
    return JsonSerializer.Serialize(results);
});

app.Run();
