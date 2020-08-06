// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

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
                /*new Client
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
                },*/
                new Client
                {
                    ClientId = "43253244523456",
                    ClientName = "Bruna Pereira",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret6".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Enfermeiro" }
                },
                new Client
                {
                    ClientId = "63465345635678",
                    ClientName = "Rodrigo Nunes",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret8".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Enfermeiro" }
                },
                new Client
                {
                    ClientId = "94885729384729",
                    ClientName = "Junior da Costa",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret9".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Enfermeiro" }
                },
                new Client
                {
                    ClientId = "73421381147293",
                    ClientName = "Gabriel Silveira",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret3".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Enfermeiro" }
                },
                new Client
                {
                    ClientId = "36221381147293",
                    ClientName = "Vinicius Oliveira",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret3".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Enfermeiro" }
                },
                new Client
                {
                    ClientId = "63729264813726",
                    ClientName = "Mateus Munin",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret6".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Enfermeiro" }
                },
                new Client
                {
                    ClientId = "89251676254293",
                    ClientName = "Sandra Mila",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret3".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Enfermeiro" }
                },
                new Client
                {
                    ClientId = "81627539471623",
                    ClientName = "Guilherme Silva",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret3".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Enfermeiro" }
                },
                new Client
                {
                    ClientId = "92637841926348",
                    ClientName = "Manuel Sidreira",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret8".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Enfermeiro" }
                },
                new Client
                {
                    ClientId = "13579246801029",
                    ClientName = "Maria Santini",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret9".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Enfermeiro" }
                },
                new Client
                {
                    ClientId = "1234567",
                    ClientName = "Alexandre Carlos",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret9".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "medico" }
                },
                new Client
                {
                    ClientId = "2241546",
                    ClientName = "Gabriel Rodrigues",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret9".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "medico" }
                },
                new Client
                {
                    ClientId = "3234546",
                    ClientName = "Breno Carlos",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret9".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "medico" }
                },
                new Client
                {
                    ClientId = "4654321",
                    ClientName = "Jurandir Santana",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret9".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "medico" }
                },
                new Client
                {
                    ClientId = "5657723",
                    ClientName = "Fernanda Santana",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret9".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "medico" }
                },
                new Client
                {
                    ClientId = "6862018",
                    ClientName = "Carlos de Oliveira",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret9".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "medico" }
                },
                new Client
                {
                    ClientId = "6648335",
                    ClientName = "Jasão Abu",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret9".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "medico" }
                },
                new Client
                {
                    ClientId = "2325592",
                    ClientName = "Enzo Gabriel",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret9".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "medico" },
                    //Claims =,
                    
                },
                new Client
                {
                    ClientId = "7846252",
                    ClientName = "Sandra Verardi",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret9".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "medico" }
                },
                new Client
                 {
                    ClientId = "1388315",
                    ClientName = "Mafalda Pinheiro",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret5".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "Medico" }
                },


            };
    }
}