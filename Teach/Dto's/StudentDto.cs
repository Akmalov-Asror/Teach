using Teach.Entities;

namespace Teach.Dto_s;

public class StudentDto
{
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public List<Room> Rooms { get; set; }
}