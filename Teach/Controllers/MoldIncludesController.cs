using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Teach.Entities;
using Teach.Services.Generics;

namespace Teach.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class MoldIncludesController<TEntity, TRepository> : ControllerBase where TEntity : class, IEntity where TRepository : IGenericRepository<TEntity>
{
    private readonly IGenericRepository<TEntity> _genericRepository;

    protected MoldIncludesController(IGenericRepository<TEntity> genericRepository) => _genericRepository = genericRepository;

    [HttpGet("include")]
    public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAllIncludingAsync([FromQuery] string[] includeProperties)
    {
        var includeExpressions = includeProperties
            .Select(property => (Expression<Func<TEntity, object>>)(x => x.GetType().GetProperty(property)))
            .ToArray();

        var entities = await _genericRepository.GetAllIncludingAsync(includeExpressions);
        return Ok(entities);
    }
}