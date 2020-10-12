using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prototipo.App;
using Prototipo.Contracts;
using Prototipo.Shared.CustomException;

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

        [HttpPost]
        public async Task<ActionResult<UsuarioResponse>> Post([FromBody] CriarUsuarioRequest request)
        {
            try
            {
                return Ok(await _usuarioApp.Incluir(request));
            }
            catch (EmailJaCadastradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao cadastrar Usuario: {ex.Message}");
                return BadRequest($"Erro ao cadastrar Usuario: {ex.Message}");
            }

        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Put(Guid id, [FromBody] AtaulizarEnderecoEntregaRequest request)
        {
            try
            {
                await _usuarioApp.AtaulizarEndereco(id, request);
                return Ok("Endereço Cadastrado com sucesso..!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao add endereço: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // POST api/<UsuarioController>
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            try
            {
                return await _usuarioApp.Login(request);
            }
            catch (EmailJaCadastradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao fazer login: {ex.Message}");
                return BadRequest($"Erro: {ex.Message}");
            }

        }


    }
}
