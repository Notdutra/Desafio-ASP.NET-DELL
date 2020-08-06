
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using demoslabs7;
using IdentityServer4.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.DataProtection;
using static IdentityModel.OidcConstants;

using GrantTypes = IdentityServer4.Models.GrantTypes;
using Microsoft.AspNetCore.Authentication;

namespace Api.Controllers
{

    [Route("Paciente")]
    [Authorize("Paciente")]
    
    public class PacienteController : ApiControllerAttribute
    {
        public int numelementos;
        public string testagem;
        private teste2Context _contexto;
        public PacienteController(teste2Context context){
            _contexto = context;
        }
        [HttpGet]
        [Route("Consulta/{client_id}")]
        
        public  ActionResult<ICollection<Consultas>> Consultas(string client_id)
        {
            if(client_id == null){
                testagem ="1" ;
            }
            else{
                testagem = "ddd";
            }
            
            numelementos = _contexto.Consultas.Where(c => c.Cpf == client_id).ToArray().Length;
            IQueryable<Consultas> consultados =  _contexto.Consultas.Where(c => c.Cpf == client_id);
            //return new JsonResult(from c in Clients.ClientId select new { c.Type, c.Value });
            return new OkObjectResult(consultados);
        }
    }
}