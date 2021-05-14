using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blagajna.Models;
using Blagajna.Services.Exceptions;
using Blagajna.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blagajna.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenIzvodController : ControllerBase
    {
        private IDenIzvodService _denIzvodService;

        public DenIzvodController(IDenIzvodService denIzvodService)
        {
            _denIzvodService = denIzvodService;
        }

        [HttpGet]
        public ActionResult<List<DenIzvodModel>> Get()
        {
            try
            {
                return Ok(_denIzvodService.GetAllDenIzvods());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!!!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<DenIzvodModel> GetById(int id)
        {
            try
            {
                return Ok(_denIzvodService.GetDenIzvodById(id));
            }
            catch (NotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!!!");
            }
        }
        
        [HttpGet("lastizvod")]
        public ActionResult<DenIzvodModel> GetLast()
        {
            try
            {
                return Ok(_denIzvodService.GetLastDenIzvod());
            }
            catch (NotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!!!");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] DenIzvodModel denIzvodModel)
        {
            try
            {
                _denIzvodService.AddDenIzvod(denIzvodModel);
                return StatusCode(StatusCodes.Status201Created, "Izvod Added");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!!!");
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] DenIzvodModel denIzvodModel)
        {
            try
            {
                _denIzvodService.UpdateDenIzvod(denIzvodModel);
                return StatusCode(StatusCodes.Status201Created, "Document Added");
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

    }
}
