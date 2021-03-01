using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

namespace API_C_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtorController : CollectionBase
    {
        [HttpPost]
        
        public Models.TbAtor Salvar(Models.TbAtor ator)
        {
            Models.apiDBContext ctx = new Models.apiDBContext();
            ctx.TbAtor.Add(ator);
            ctx.SaveChanges();

            return ator;
        }

        [HttpGet]

        public List<Models.TbAtor> Listar()
        {
            Models.apiDBContext ctx = new Models.apiDBContext();
            List<Models.TbAtor> atores = ctx.TbAtor.ToList();

            return atores;
        }

    }
}