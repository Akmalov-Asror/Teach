namespace Teach.Entities;

public class Teachers : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Level { get; set; }
    public string Science { get; set; }
}