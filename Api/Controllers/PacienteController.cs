
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using GrantTypes = IdentityServer4.Models.GrantTypes;
using Microsoft.AspNetCore.Authentication;
using IdentityServer4.Services;

namespace Api.Controllers
{

    [Route("Paciente")]
    [Authorize("Paciente")]
    
    
    public class PacienteController : ApiControllerAttribute
    {
        public int numelementos;
        public string testagem;
        public IEnumerable<AuthenticationToken> tokem;
        //private IIdentityServerInteractionService _interaction;
        private teste2Context _contexto;
        //private AuthenticationProperties _de;
        public PacienteController(teste2Context context){
            _contexto = context;
            
            //AuthenticationProperties _de = de;
        }
        [HttpGet]
        [Route("Consulta/{client_id}")]
        
        public async Task<ActionResult<ICollection<Consultas>>> ConsultasAsync(string client_id)
        {
            //var clientela = await _interaction.GetAuthorizationContextAsync("https://localhost:5001");
            //var identidade = clientela.Client.ClientId;
            if(client_id == null){
                //return new OkObjectResult(identidade);
                return new BadRequestResult();
            }
            else{

                var TenteCpf = _contexto.Consultas.Where(C => C.Cpf == client_id);
                
                var tente = TenteCpf.OrderBy (t => t.Crm)
                .Join (_contexto.Medicos,
                    consulta => consulta.Crm,
                    medico => medico.Crm,
                    
                    (consulta, medico) => new {
                        Medico = medico.Nome,
                            Coren = consulta.Coren,
                            CPF = consulta.Cpf,
                            DataConsulta = consulta.DataConsulta,
                            CodTriagem = consulta.CodTriagem
                    });

                  var tente2 =  tente.Join(_contexto.Pacientes,              
                    consulta => consulta.CPF,
                    paciente => paciente.Cpf,
                    ( consulta,paciente) => new {
                        Medico = consulta.Medico,
                            paciente = paciente.Nome,
                            Coren = consulta.Coren,
                            DataConsulta = consulta.DataConsulta,
                            CodTriagem = consulta.CodTriagem
                    }
                );

              var tente3 = tente2.Join(_contexto.Triagem,
                    consulta => consulta.CodTriagem , // como dar outerjoin??
                    triagem => triagem.CodTriagem,              
                    ( consulta,triagem) => new {
                        Medico = consulta.Medico,
                            descricao = triagem.DescricaoPaciente,
                            paciente = consulta.paciente,
                            Coren = consulta.Coren,
                            DataConsulta = consulta.DataConsulta,
                    }
                );
                var algo = tente3.Select(C => new{C.Medico,C.paciente,C.Coren,C.DataConsulta,C.descricao});
                //IQueryable<Consultas> consultados =  _contexto.Consultas.Where(c => c.Cpf == client_id);
                //var algo = consultados.Select(m=> new{m.Cpf,m.DataConsulta});

                return new OkObjectResult(algo);
                
            }
            
            //numelementos = _contexto.Consultas.Where(c => c.Cpf == client_id).ToArray().Length;
            
        }
    }
}