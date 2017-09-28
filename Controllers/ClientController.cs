using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using clientprj.Domain.Util;
using clientprj.Domain;
using clientprj.Domain.Client;
using clientprj.DTO;
using clientprj.Infrastructure;
using clientprj.Services;
using Microsoft.AspNetCore.Mvc;

namespace clientprj.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private IClientService service;

        public ClientController(ClientContext _context, IClientService _service)
        {
            this.service = _service;
        }

        [HttpGet]
        public IEnumerable<ClientDTO> GetAll()
        {
            return this.service.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cli = this.service.GetById(id);

            if (cli == null) return NotFound();

            return new ObjectResult(cli);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ClientDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            
            var cli = this.service.Add(item);

            return new ObjectResult(cli);            
        }

        [HttpPut]
        public IActionResult Update([FromBody] ClientDTO item)
        {
            if (item == null || (item != null && item.Id == null))
            {
                return BadRequest();
            }
            try
            {
                this.service.Update(item);

                return new NoContentResult();
            }
            catch(Domain.Util.DomainException de)
            {
                var err = string.Empty;
                de.Errors.ForEach(e => err += e + Environment.NewLine);
                Console.WriteLine(err);
                return BadRequest(err);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {            
            this.service.Remove(id);
         
            return new NoContentResult();
        }

    }
}
