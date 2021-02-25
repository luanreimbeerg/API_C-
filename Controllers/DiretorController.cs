using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

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
        
    }
}