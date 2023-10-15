using Teach.Data;
using Teach.Entities;
using Teach.Services.Generics;

namespace Teach.Repositories;

public class TeacherRepository : GenericRepository<Teachers,AppDbContext>
{
    public TeacherRepository(AppDbContext context) : base(context) { }
}