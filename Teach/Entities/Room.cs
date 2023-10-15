namespace Teach.Entities;

public class Room : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StudentCount { get; set; }
}