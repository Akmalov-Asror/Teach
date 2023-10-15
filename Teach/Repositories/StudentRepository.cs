using Teach.Data;
using Teach.Entities;
using Teach.Services.Generics;

namespace Teach.Repositories;

public class StudentRepository : GenericRepository<Student, AppDbContext>
{
    public StudentRepository(AppDbContext context) :base(context) { }
}