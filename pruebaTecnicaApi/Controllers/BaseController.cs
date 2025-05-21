using System.Net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using DTO.Common;
using pruebaTecnicaApi.Authorization;

namespace pruebaTecnicaApi.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [EnableCors("MyCorsPolicyCustomable")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected async Task<ObjectResult> GetReponseAnswer(dynamic? response)
        {
            return await Task.Run(
                () =>
                {
                    return new ObjectResult(new HttpResponseDto { Data = response != null ? response : null})
                    { StatusCode = (int)HttpStatusCode.OK };
                });
        }
    }
}
