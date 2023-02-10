namespace WebApiDemo.Domains;

public class Book
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Isbn { get; set; }
    public float Price { get; set; }
    public string Author { get; set; }
}