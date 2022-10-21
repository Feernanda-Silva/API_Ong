using System.Collections.Generic;
using API_Ong.Models;
using API_Ong.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Ong.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService _pessoaService; 

        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public ActionResult<List<Pessoa>> Get() => _pessoaService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPessoa")]
        public ActionResult<Pessoa> Get(string id)
        {
            var pessoa = _pessoaService.Get(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }
        [HttpPost]
        public ActionResult<Pessoa> Create(Pessoa pessoa)
        {
            _pessoaService.Create(pessoa);
            return CreatedAtRoute("GetPessoa", new { id = pessoa.Id.ToString() }, pessoa);
        }

        [HttpPut]
        public ActionResult<Pessoa> Put(Pessoa pessoaIn, string id)
        {
            var pessoa = _pessoaService.Get(id);
            if (pessoa == null)
            {
                return NotFound("Não encontrado");
            }
            _pessoaService.Update(pessoa.Id, pessoaIn);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Pessoa> Delete(string id)
        {
            Pessoa pessoa = _pessoaService.Get(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            _pessoaService.Remove(pessoa);

            return NoContent();
        }

    }
}
