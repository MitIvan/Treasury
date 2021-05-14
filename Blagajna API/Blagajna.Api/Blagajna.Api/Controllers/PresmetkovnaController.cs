using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blagajna.Domain.Shared.Models;
using Blagajna.Services.Implementation;
using Blagajna.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blagajna.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresmetkovnaController : ControllerBase
    {
        private IPresmetkovnaEd _presmetkovnaService;

        public PresmetkovnaController(IPresmetkovnaEd presmetkovnaService)
        {
            _presmetkovnaService = presmetkovnaService;
        }

        [HttpGet]
        public ActionResult<List<PresmetkovnaEd>> Get()
        {
            try
            {
                return Ok(_presmetkovnaService.GetPresmetkovnaEds()); 
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!!!");
            }
        }

    }
}
