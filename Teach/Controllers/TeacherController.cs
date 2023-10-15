using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teach.Entities;
using Teach.Repositories;

namespace Teach.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "ADMIN")]
public class TeacherController : MoldController<Teachers, TeacherRepository>
{
    public TeacherController(TeacherRepository teacherRepository) :base(teacherRepository) { }
}