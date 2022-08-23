using Domain.Models;
using Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContatosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatosController : Controller
    {
        private readonly ContatoDBContext dbContext;
        public ContatosController(ContatoDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContatos()
        {
            return Ok(await dbContext.Contatos.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContato([FromRoute] Guid id)
        {
            var contato = await dbContext.Contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        [HttpPost]
        public async Task<IActionResult> AddContato(ContatoRequestModel contatoRequest)
        {
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Endereco = contatoRequest.Endereco,
                Email = contatoRequest.Email,
                Nome = contatoRequest.Nome,
                Telefone = contatoRequest.Telefone
            };

            await dbContext.Contatos.AddAsync(contato);
            await dbContext.SaveChangesAsync();

            return Ok(contato);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContato([FromRoute] Guid id, ContatoRequestModel contatoRequest)
        {
            var contato = await dbContext.Contatos.FindAsync(id);
            if (contato != null)
            {
                contato.Email = contatoRequest.Email;
                contato.Nome = contatoRequest.Nome;
                contato.Telefone = contatoRequest.Telefone;
                contato.Endereco = contatoRequest.Endereco;

                await dbContext.SaveChangesAsync();
                return Ok(contato);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContato([FromRoute] Guid id)
        {
            var contato = await dbContext.Contatos.FindAsync(id);
            if (contato != null)
            {
                dbContext.Remove(contato);
                await dbContext.SaveChangesAsync();
                return Ok(contato);
            }

            return NotFound();
        }
    }
}
