// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api.Models;
using System.Collections.Generic;

namespace Api.Controllers
{

    [Route("Funcionario")]
    [Authorize("Funcionario")]
    
    public class FuncionarioController : ControllerBase
    {
        public FuncionarioController(teste2Context context){
            _contexto = context;
        }
        private readonly teste2Context _contexto;
        [Route("Consultas")]
        public IActionResult Consultas()
        {
            
            return new OkObjectResult(_contexto.Consultas.OrderBy(t => t.Cpf));
            
        }

        [Route("Pacientes")]

        public IActionResult BuscaPaciente(){

            return new OkObjectResult(_contexto.Pacientes.OrderBy(t => t.Cpf));
        }

        [Route("Triagem")]

        public IActionResult BuscaTriagem(){

            return new OkObjectResult(_contexto.Triagem.OrderBy(t => t.Cpf));

        }

        [Route("Enfermeiros")]

        public IActionResult BuscaEnfermeiros(){

            return new OkObjectResult(_contexto.Enfermeiros.OrderBy(t => t.Coren).Select(E => new{E.Nome,E.Coren}));

        }

        [Route("Medicos")]

        public IActionResult BuscaMedicos(){

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