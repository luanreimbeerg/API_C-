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
        
    }
}