
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



namespace Api.Controllers
{

    [Route("Paciente")]
    [AllowAnonymous]
    
    public class PacienteController : ControllerBase
    {
        public int numelementos;
        private teste2Context _contexto;
        public PacienteController(teste2Context context){
            _contexto = context;
        }
        [HttpGet]
        public  ActionResult<ICollection<Consultas>> Consultas()
        {
            
            if(_contexto == null){
                numelementos =1 ;
            }
            else{
                numelementos = 2;
            }
            numelementos = _contexto.Consultas.Where(c => c.Cpf == "13145232242").ToArray().Length;
            Consultas consultados =  _contexto.Consultas.Where(c => c.Cpf == "13145232242").FirstOrDefault();
            return BadRequest(numelementos);
        }
    }
}