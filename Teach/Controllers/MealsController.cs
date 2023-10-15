using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teach.Entities;
using Teach.Repositories;

namespace Teach.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MealsController : MoldController<Meals, MealRepository>
{
    public MealsController(MealRepository mealRepository) :base(mealRepository) { }
}