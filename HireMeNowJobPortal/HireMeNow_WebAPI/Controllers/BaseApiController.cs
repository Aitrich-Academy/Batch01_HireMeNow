using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiremenowAdmin.Controllers
{
    [Route("api/v1")]
    public abstract class BaseApiController<T> : ControllerBase
    {

    }
}
