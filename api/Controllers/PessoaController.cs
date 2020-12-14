using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteCrud.Data;
using TesteCrud.Models;

namespace TesteCrud.Controllers
{
    [ApiController]
    [Route("v1/pessoas")]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get(
            [FromServices] DataContext context)
        {
            try
            {

                var pessoas = await context.Pessoas.Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Email,
                    x.DataNascimento,
                    idade = DateTime.Now.Year - x.DataNascimento.Year

                }).ToListAsync();
                return Ok(pessoas);
            }
            catch (System.Exception e)
            {
                return BadRequest(new
                {
                    Code = 500,
                    Message = e.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(
        [FromServices] DataContext context,
        int id)
        {
            try
            {
                var pessoa = await context.Pessoas.Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Email,
                    x.DataNascimento,
                    idade = DateTime.Now.Year - x.DataNascimento.Year

                }).FirstOrDefaultAsync(x => x.Id == id);
                return Ok(pessoa);

            }
            catch (System.Exception e)
            {

                return BadRequest(new
                {
                    Code = 500,
                    Message = e.Message
                });
            }

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Pessoa>> Post(
            [FromServices] DataContext context,
            [FromBody] Pessoa model)
        {
            try
            {
                context.Pessoas.Add(model);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "Usuario Criado",
                    Pessoa = model
                });

            }
            catch (System.Exception e)
            {

                return BadRequest(new
                {
                    Code = 500,
                    Message = e.Message
                });
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Put(
            [FromServices] DataContext context,
            [FromBody] Pessoa model)
        {
            try
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return Ok(new
                {

                    Message = "Usuario atualizado",
                    Pessoa = model
                });
            }
            catch (System.Exception e)
            {
                return BadRequest(new
                {
                    Code = 500,
                    Message = e.Message
                });
            }
        }

        [HttpDelete("{id}")]
        [Route("")]
        public async Task<ActionResult> Delete(
            [FromServices] DataContext context,
            int id)
        {
            try
            {
                var pessoa = await context.Pessoas.FirstOrDefaultAsync(x => x.Id == id);
                context.Pessoas.Remove(pessoa);
                await context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "Usuario Deletado",
                    Pessoa = pessoa
                });
            }
            catch (System.Exception e)
            {
                return BadRequest(new
                {
                    Code = 500,
                    Message = e.Message
                });
            }
        }
    }
}

