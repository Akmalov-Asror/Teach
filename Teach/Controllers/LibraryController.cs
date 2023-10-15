using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teach.Entities;
using Teach.Repositories;

namespace Teach.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibraryController : MoldController<Library,  LibraryRepository>
{
    public LibraryController(LibraryRepository libraryRepository) : base(libraryRepository) { }
}