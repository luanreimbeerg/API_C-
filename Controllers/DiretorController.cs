using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace API_C_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiretorController : CollectionBase
    {
        [HttpPost]

        public Models.TbDiretor Salvar(Models.TbDiretor diretor)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();
            ctx.TbDiretor.Add(diretor);
            ctx.SaveChanges();
            
            return diretor;
        }

        [HttpPost("filme")]

        public Models.Response.DiretorPorFilmeResponse SalvarPorFilme(Models.Request.DiretorRequest diretorR)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();

            Models.TbFilme filme = ctx.TbFilme.First(x =>x.NmFilme == diretorR.NmFilme);

            Models.TbDiretor diretor = new Models.TbDiretor();
            diretor.NmDiretor = diretorR.NmDiretor;
            diretor.DtNascimento = diretorR.DtNascimento;
            diretor.IdFilme = filme.IdFilme;

            ctx.TbDiretor.Add(diretor);
            ctx.SaveChanges();

            Models.Response.DiretorPorFilmeResponse resp = new Models.Response.DiretorPorFilmeResponse();
            resp.idDiretor = diretor.IdDiretor;
            resp.NmDiretor = diretor.NmDiretor;
            resp.NmFilme = filme.NmFilme;
            resp.DtNascimento = diretor.DtNascimento;

            return resp;
        }
        
        [HttpGet]

        public List<Models.Response.DiretorResponse> Listar()
        {
            Models.apiDBContext ctx = new Models.apiDBContext();
            List<Models.TbDiretor>diretores = ctx.TbDiretor.Include(x => x.IdFilmeNavigation).ToList();

            List<Models.Response.DiretorResponse> response = diretores.Select(x => new Models.Response.DiretorResponse{
                idDiretor = x.IdDiretor,
                idFilme = x.IdFilme,
                Filme = x.IdFilmeNavigation.NmFilme,
                Genero = x.IdFilmeNavigation.DsGenero,
                Disponivel = x.IdFilmeNavigation.BtDisponivel
            }).ToList();

            return response;
        
        }

        
       [HttpGet("consultar")]

        public List<Models.TbDiretor> Consultar(string nome )
       {
           Models.apiDBContext ctx = new Models.apiDBContext();
           List<Models.TbDiretor>diretores = ctx.TbDiretor.Where(x =>x.NmDiretor == nome ).ToList();

            return diretores;
        
       }
    }
}