// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("medico", "Medico"),
                new ApiScope("Enfermeiro", "Enfermeiro"),
                new ApiScope("Paciente","Paciente")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "13145232242",
                    ClientName = "Rosa Silveira",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret2".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Paciente" }
                },
                new Client
                {
                    ClientId = "52395029582",
                    ClientName = "Pedro Gusmão",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret2".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Paciente" }
                },
                new Client
                {
                    ClientId = "84495039284",
                    ClientName = "Rafael Gomes",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret4".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Paciente" }
                },
                new Client
                {
                    ClientId = "40920540395",
                    ClientName = "Pietra Oliveira",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret5".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Paciente" }
                },
                new Client
                {
                    ClientId = "57294953043",
                    ClientName = "Paola da Silva",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret3".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Paciente" }
                },
                new Client
                {
                    ClientId = "11122233345",
                    ClientName = "Kratos de Machado",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret3".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Paciente" }
                },
                new Client
                {
                    ClientId = "05219428134",
                    ClientName = "Joel Silveira",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret4".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Paciente" }
                },
                new Client
                {
                    ClientId = "81643218521",
                    ClientName = "Juliana Rosa",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret3".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Paciente" }
                },
                new Client
                {
                    ClientId = "14754621894",
                    ClientName = "Mariana Fantinelli",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret3".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Paciente" }
                },
                new Client
                {
                    ClientId = "84316574921",
                    ClientName = "Fernando Augusto",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret3".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Paciente" }
                },


            };
    }
}