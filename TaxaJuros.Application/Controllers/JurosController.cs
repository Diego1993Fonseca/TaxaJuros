using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxaJuros.Domain.Intefaces.Business;
using TaxaJuros.Domain.Model.DTO;

namespace TaxaJuros.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JurosController : ControllerBase
    {
        readonly IJurosServices _service;

        public JurosController(IJurosServices service)
        {
            _service = service;
        }

        [HttpGet("taxaJuros")]
        public ActionResult<JurosDTO> Get()
        {
            try {  
                var response = _service.GetJuros();

                if (response == null)
                    throw new InvalidOperationException("Informação não encontrada");

                return response;
            }catch(Exception ex) 
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message
                });

            }



        }
    }
}
