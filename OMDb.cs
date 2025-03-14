namespace MovieBox.OMDb;

public class OmdbRating
{
  public string Source = "";
  public string Value = "";
}

public class OmdbMovie
{
  public string Title { get; set; } = "";
  public string Year { get; set; } = "";
  public string imdbID { get; set; } = "";
  public string Type { get; set; } = "";
  public string Poster { get; set; } = "";
}

public class OmdbMovieFull
{
  public string Title = "";
  public string Year = "";
  public string? Rated;
  public string? Released;
  public string? Runtime;
  public string? Genre;
  public string? Director;
  public string? Writer;
  public string? Actors;
  public string? Plot;
  public string? Language;
  public string? Country;
  public string? Awards;
  public string? Poster;
  public List<OmdbRating>? Ratings;
  public string? Metascore;
  public string? imdbRating;
  public string? imdbVotes;
  public string imdbID = "";
  public string? Type;
  public string? DVD;
  public string? BoxOffice;
  public string? Production;
  public string? Website;
  public string? Response;
}

public class OmdbSearch
{
  public List<OmdbMovie> Search { get; set; } = [];
  public string Response { get; set; } = "";
  public string? Error { get; set; } = "";
  public string totalResults { get; set; } = "";
}