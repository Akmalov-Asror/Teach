using Teach.Data;
using Teach.Entities;
using Teach.Services.Generics;

namespace Teach.Repositories;

public class LibraryRepository : GenericRepository<Library, AppDbContext>
{
    public LibraryRepository(AppDbContext context) : base(context) { }
}