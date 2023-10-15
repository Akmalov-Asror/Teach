using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Teach.Entities;
using Teach.Repositories;

namespace Teach.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "ADMIN")]
[Authorize(Roles = "TEACHER")]
public class StudentsController : MoldController<Student, StudentRepository>
{
    private readonly StudentRepository _studentRepository;

    public StudentsController(StudentRepository studentRepository) : base(studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet("include")]
    public virtual async Task<ActionResult<IEnumerable<Student>>>
        GetAllIncludingAsync([FromQuery] string[] includeProperties)
    {
        var includeExpressions = includeProperties
            .Select(property => (Expression<Func<Student, object>>)(x => x.GetType().GetProperty(property)))
            .ToArray();

        var entities = await _studentRepository.GetAllIncludingAsync(includeExpressions);
        return Ok(entities);
    }
}