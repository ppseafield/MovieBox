namespace MovieBox.OMDb;

public record OmdbRating
{
  public string Source = "";
  public string Value = "";
}
public record OmdbMovie
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

