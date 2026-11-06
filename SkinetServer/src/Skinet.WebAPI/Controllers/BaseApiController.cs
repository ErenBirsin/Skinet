using Microsoft.AspNetCore.Mvc;
using Skinet.Core;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.WebAPI.RequestHelpers;

namespace Skinet.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    public async Task<ActionResult> CreatePageResult<T>(IGenericRepository<T> repo,
        ISpecification<T> spec, int pageIndex, int pageSize) where T : BaseEntity
    {
        var items = await repo.ListAsync(spec);
        var count = await repo.CountAsync(spec);

        var pagination = new Pagination<T>(pageIndex,pageSize,count,items);

        return Ok(pagination);
    }
}
