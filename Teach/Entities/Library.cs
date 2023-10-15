namespace Teach.Entities;

public class Library : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public int Price { get; set; }
}