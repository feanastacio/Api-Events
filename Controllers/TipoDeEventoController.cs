using Api_Event.Domains;
using Api_Event.Interface;
using Api_Event.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoDeEventoController : ControllerBase
    {
        private readonly ITipoDeEventoRepository _tipoeventorepository;
        public TipoDeEventoController(ITipoDeEventoRepository tipoeventorepository)
        {
            _tipoeventorepository = tipoeventorepository;
        }

        //Metodo Listar
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoDeEvento> listaTiposDeEventos = _tipoeventorepository.Listar();
                return Ok(listaTiposDeEventos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Metodo Cadastrar
        [Authorize]
        [HttpPost]
        public IActionResult Post(TipoDeEvento novoTipoDeEvento)
        {
            try
            {
                _tipoeventorepository.Cadastrar(novoTipoDeEvento);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Metodo Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoDeEvento tipoDeEvento)
        {
            try
            {
                _tipoeventorepository.Atualizar(id, tipoDeEvento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Metodo Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _tipoeventorepository.Deletar(Id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
