// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;
using System.Collections.Generic;

namespace Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            X509Certificate2 certificate = new X509Certificate2("certificate.pfx", "secret");
            //services.AddHttpClient();
            services.AddDbContext<teste2Context>(opt => {
                opt.UseSqlServer(@"server=W107CLHD33;database=teste2;trusted_connection=yes");
            });
            //IdentityModelEventSource.ShowPII = true;
            services.AddControllers();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // accepts any access token issued by identity server
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {  
                    
                    options.Authority = "https://localhost:5001";
                    options.BackchannelHttpHandler = clientHandler;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        
                        
                        
                        
                    };
                    options.SaveToken=true;
                    //option.
                });
            //services.AddCertificateForwarding(certificate);
            // adds an authorization policy to make sure the token is for scope 'api1'
            //services.
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Paciente", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "Paciente");
                    //policy.RequireClaim()

                });
                options.AddPolicy("Funcionario", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", new List<string>{"medico", "Enfermeiro"});
                    //policy.RequireClaim("scope", "Enfermeiro");
                });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers()
                //    .RequireAuthorization("Paciente");
                endpoints.MapControllerRoute("Funcionario","Funcionario/").RequireAuthorization("Funcionario");
                endpoints.MapControllerRoute("Paciente","Paciente/").RequireAuthorization("Paciente");
            });
        }
    }
}
