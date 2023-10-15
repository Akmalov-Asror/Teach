using Teach.Data;
using Teach.Entities;
using Teach.Services.Generics;

namespace Teach.Repositories;

public class RoomRepository : GenericRepository<Room,AppDbContext>
{
    public RoomRepository(AppDbContext context) : base(context) { }
}