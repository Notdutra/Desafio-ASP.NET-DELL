// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api.Models;

namespace Api.Controllers
{

    [Route("Especialidades")]
    [AllowAnonymous]
    
    public class AnonimatoController : ControllerBase
    {
        private readonly teste2Context _contexto;
        public IActionResult Get()
        {
            
            return new OkObjectResult("sucess manito");
            
        }
    

    [Route("Medicos")]
    [AllowAnonymous]
        public IActionResult BuscaMedicosAnonimato(){

            return new OkObjectResult(_contexto.Medicos.OrderBy(t => t.Crm)
                                    .Join(_contexto.Especialidades,
                                    medico => medico.CodEspecialidade,
                                    especial => especial.CodEspecialidade,
                                    (medico, especial)=> new {
                                        Nome = medico.Nome,
                                        Crm = medico.Crm,
                                        Especialidade = especial.Nome 
                                    })
                                    .Select(M => new {M.Crm,M.Nome,M.Especialidade}));

        }
    }
}