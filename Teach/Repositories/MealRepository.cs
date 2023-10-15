using Teach.Data;
using Teach.Entities;
using Teach.Services.Generics;

namespace Teach.Repositories;

public class MealRepository : GenericRepository<Meals, AppDbContext>
{
    public MealRepository(AppDbContext context) : base(context) { }
}