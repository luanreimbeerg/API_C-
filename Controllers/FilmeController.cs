using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

namespace API_C_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        [HttpPost]        
        public Models.TbFilme Salvar(Models.TbFilme filme)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();
            ctx.TbFilme.Add(filme);
            ctx.SaveChanges();

            return filme;
        }

        [HttpGet]

        public List<Models.TbFilme>Listar()
        {
            Models.apiDBContext ctx = new Models.apiDBContext();
            List<Models.TbFilme> filmes =ctx.TbFilme.ToList();
            return filmes;
            
        }

        [HttpGet("consultar")]

        public List<Models.TbFilme>Cosultar(string genero)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();
            List<Models.TbFilme> filmes =ctx.TbFilme.Where(x => x.DsGenero == genero).ToList();
            return filmes;
            
        }

        [HttpPut]

        public void Alterar(Models.TbFilme filme)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();

            Models.TbFilme altual= ctx.TbFilme.FirstOrDefault(x => x.IdFilme == filme.IdFilme);
            altual.NmFilme = filme.NmFilme;
            altual.DsGenero = filme.DsGenero;
            altual.NrDuracao = filme.NrDuracao;
            altual.VlAvaliacao = filme.VlAvaliacao;
            altual.BtDisponivel = filme.BtDisponivel;
            altual.DtLancamento = filme.DtLancamento;

            ctx.SaveChanges();
        }

        [HttpDelete]

        public void Remover (Models.TbFilme filme)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();

            Models.TbFilme remove =  ctx.TbFilme.FirstOrDefault(x => x.IdFilme == filme.IdFilme);

            ctx.TbFilme.Remove(remove);

            ctx.SaveChanges();
        }


        [HttpDelete("genero")]

        public void remover (Models.TbFilme filme)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();

            List<Models.TbFilme> filmes = ctx.TbFilme.Where(x => x.DsGenero == filme.DsGenero).ToList();

            ctx.TbFilme.RemoveRange(filmes);
            ctx.SaveChanges();
        }
        
    }
}