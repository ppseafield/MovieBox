namespace MovieBox.Types;

using MovieBox.DB;
using MovieBox.OMDb;

public class MovieSearchResponse {
  public List<OmdbMovie> movies { get; set; } = [];
  public List<MovieReview> reviews { get; set; } = [];
}

