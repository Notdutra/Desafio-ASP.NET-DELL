// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api.Models;

namespace Api.Controllers
{

    [Route("identity")]
    [Authorize]
    
    public class IdentityController : ControllerBase
    {
        private readonly teste2Context _contexto;
        public IActionResult Get()
        {
            
            return new BadRequestObjectResult("sucess manito");
            
        }
    }
}