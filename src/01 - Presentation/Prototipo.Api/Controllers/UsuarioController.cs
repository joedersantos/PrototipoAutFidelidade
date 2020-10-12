using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prototipo.App;
using Prototipo.Contracts;

namespace Prototipo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioAppService _usuarioApp;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioAppService usuarioApp)
        {
            _logger = logger;
            _usuarioApp = usuarioApp;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] CriarUsuarioRequest request)
        {
            try
            {
                await _usuarioApp.Incluir(request);
                return Ok("Usuario Cadastrado com sucesso..!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao cadastrar Usuario: {ex.Message}");
                return BadRequest($"Erro ao cadastrar Usuario: {ex.Message}");
            }
           
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
