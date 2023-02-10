namespace WebApiDemo.Domains;

public class Movie
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public long Duration { get; set; }
    public string Director { get; set; }
    public string PosterUrl { get; set; }
    public string Actors { get; set; }
}