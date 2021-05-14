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
    public class DenDocumentController : ControllerBase
    {
        private IDenDocumentService _denDocumentService;

        public DenDocumentController(IDenDocumentService denDocumentService)
        {
            _denDocumentService = denDocumentService;
        }

        [HttpGet]
        public ActionResult<List<DenDocumentModel>> Get()
        {
            try
            {
                return Ok(_denDocumentService.GetAllDenDocumentsFinalIzvodFalse());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!!!");
            }
        }
        [HttpGet("{id}")]
        public ActionResult<DenDocumentModel> GetById(int id)
        {
            try
            {
                return Ok(_denDocumentService.GetDenDocumentById(id));
            }
            catch(NotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!!!");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] DenDocumentModel denDocumentModel)
        {
            try
            {
                _denDocumentService.AddDenDocument(denDocumentModel);
                return StatusCode(StatusCodes.Status201Created, "Document Added");
            }
            catch (DenDocumentExeption e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!!!");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] DenDocumentModel denDocumentModel)
        {
            try
            {
                _denDocumentService.UpdateDenDocument(denDocumentModel);
                return StatusCode(StatusCodes.Status201Created, "Document Added");
            }
            catch (DenDocumentExeption e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!!!");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult  Delete(int id)
        {
            try
            {
                _denDocumentService.DeleteDenDocument(id);
                return StatusCode(StatusCodes.Status204NoContent, "Document Deleted");
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
    }
}
