using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blagajna.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blagajna.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Vraboten : ControllerBase
    {
        private IVraboten _vrabotenService;

        public Vraboten(IVraboten vrabotenService)
        {
            _vrabotenService = vrabotenService;
        }

        [HttpGet]
        public ActionResult<List<Vraboten>> Get()
        {
            try
            {
                return Ok(_vrabotenService.GetAllVraboteni());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!!!");
            }
        }
    }
}
