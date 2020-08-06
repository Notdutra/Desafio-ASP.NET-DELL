// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Linq;
using IdentityServer4.EntityFramework.Mappers;

namespace IdentityServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // uncomment, if you want to add an MVC-based UI
            //services.AddControllersWithViews();
            
            var connectionString = @"server=W107CLHD33;database=teste2;trusted_connection=yes";
             var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var cert = new X509Certificate2("fred.pfx", "apples");
            var construtor = services.AddIdentityServer()
                    .AddSigningCredential(new X509Certificate2("certificate.pfx", "secret"))
                    //.AddTestUsers(Config.GetUsers())
                    .AddConfigurationStore(builder =>
                        builder.ConfigureDbContext = b => b.UseSqlServer(connectionString, options =>
                            options.MigrationsAssembly(migrationsAssembly)))
                    .AddOperationalStore(builder =>
                         builder.ConfigureDbContext = b => b.UseSqlServer(connectionString, options =>
                            options.MigrationsAssembly(migrationsAssembly)));

            //builder.AddDeveloperSigningCredential();
        }

        public void Configure(IApplicationBuilder app)
        {
            InitializeDatabase(app);    
            app.UseDeveloperExceptionPage();

            // uncomment if you want to add MVC
            //app.UseStaticFiles();
            //app.UseRouting();

            app.UseIdentityServer();

            // uncomment, if you want to add MVC-based
            //app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //});
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<IdentityServer4.EntityFramework.DbContexts.PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<IdentityServer4.EntityFramework.DbContexts.ConfigurationDbContext>();
                //serviceScope.ServiceProvider.GetRequiredService<HospitalContext>().Database.Migrate();
                context.Database.Migrate();

                 if (context.ApiResources.Any())
                {
                    foreach (var resource in Config.ApiScopes)
                    {
                        context.ApiScopes.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
                if (!context.Clients.Any())
        {
                    foreach (var client in Config.Clients)
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
         }
    }
    
}