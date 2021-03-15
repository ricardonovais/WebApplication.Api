using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Api.Context;
using WebApplication.Api.Models;
using WebApplication.Api.Services;

namespace WebApplication.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        public ClientesController(AppDbContext appDbContext) => _clienteService = new ClienteService(appDbContext);
        
        [HttpGet]
        public async Task<ActionResult<Cliente>> Get()
        {
            var clientes = await _clienteService.Get();

            return Ok(clientes);
        }

        [HttpGet("{id}", Name = "RetornaCliente" )]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await _clienteService.Get(id);

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente cliente)
        {
            await _clienteService.Add(cliente);

            return new CreatedAtRouteResult("RetornaCliente", new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id) return BadRequest();

            await _clienteService.Update(cliente);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clienteService.Delete(id);

            return Ok();
        }
    }
}
