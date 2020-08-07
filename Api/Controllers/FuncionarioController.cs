// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api.Models;
using System.Collections.Generic;
using System;

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
        [Route("Consultas{cliente_id}")]
        public IActionResult Consultas(string cliente_id)
        {
            var tenteinicial = _contexto.Consultas.Select(C => new{C.Cpf,C.Coren,C.CodTriagem, C.Crm,C.DataConsulta});
            if(!((cliente_id == null) || (cliente_id == ""))){ 
               tenteinicial = tenteinicial.Where(C => C.Cpf == cliente_id);
            }
            
            var tente = tenteinicial.OrderBy (t => t.Crm)
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

            //tente3.Join()
            
            
            return new OkObjectResult (tente3);
        }

        [Route("Pacientes")]

        public IActionResult BuscaPaciente(){

            return new OkObjectResult(_contexto.Pacientes.Select(p => new{p.Nome,p.Sexo}));
        }

        [Route("Triagem")]

        public IActionResult BuscaTriagem(){
            
            var tente = _contexto.Triagem.Select(C =>new{C.DataConsulta,C.Cpf,C.Coren,C.DescricaoPaciente,C.Prioridade});

            var tente2 = tente.Join(_contexto.Pacientes,
                                    triagem => triagem.Cpf,
                                    P => P.Cpf,
                                    (triagem,P)=> new{
                                        NomePaciente = P.Nome,
                                        Coren = triagem.Coren,
                                        Data = triagem.DataConsulta,
                                        Descricao = triagem.DescricaoPaciente,
                                        Prioridade = triagem.Prioridade
                                    });

            return new OkObjectResult(tente2);

        }

        [Route("Enfermeiros")]

        public IActionResult BuscaEnfermeiros(){

            return new OkObjectResult(_contexto.Enfermeiros.OrderBy(t => t.Coren).Select(E => new{E.Nome,E.Coren}));

        }

        [Route("Medicos{crm}")]

        public IActionResult BuscaMedicos(string crm){
            //if(crm == null)

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