using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Notes.Server.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BaseController : ControllerBase
{
    private IMapper? _mapper;

    protected IMapper Mapper =>
        _mapper ??= HttpContext.RequestServices.GetService<IMapper>();

    internal Guid UserId => !User.Identity.IsAuthenticated
        ? Guid.Empty
        : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
}
