// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

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
using System.Collections.Generic;
using GrantTypes = IdentityServer4.Models.GrantTypes;

namespace Api.Controllers
{

    [Route("Registrar")]
    [AllowAnonymous]
    public class RegisterController : ControllerBase
    {
        private readonly teste2Context _contexto;
        
        [HttpPost]
        public async Task<IActionResult> RegistrarMedico(RegistroMedico rmedico){
            Medicos medico = new Medicos();
            medico.Crm = rmedico.R_CRM;
            medico.Nome = rmedico.R_Nome;
            medico.CodEspecialidade = rmedico.R_cod_especialidade;

            Client cliente = new Client();
            cliente.ClientId = medico.Crm;
            cliente.ClientName = medico.Nome;
            cliente.ClientSecrets = new List<IdentityServer4.Models.Secret>{new IdentityServer4.Models.Secret(rmedico.R_Senha.Sha256())};
            cliente.AllowedGrantTypes = GrantTypes.ClientCredentials;
            cliente.AllowedScopes = new List<string> {"medico"};
            
            return BadRequest();
        }
    }   
}