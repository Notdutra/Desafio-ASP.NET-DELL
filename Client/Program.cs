// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityModel.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        private static async Task Main()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //clientHandler.cert
            //var cert = new X509Certificate2("fred.pfx", "apples");
            HttpClientHandler handler = new HttpClientHandler();
            X509Certificate2 certificate = new X509Certificate2("certificate.pfx", "secret");
            handler.ClientCertificates.Add(certificate);
            if(certificate == null){
                Console.WriteLine("certificado ta nulo");
            }
            handler.ClientCertificates.Add(certificate);
            //HttpClient client = new HttpClient(handler);
            // discover endpoints from metadata
            var client = new HttpClient(clientHandler);

            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "13145232242",
                ClientSecret = "secret2",

                Scope = "Paciente"
            });
            //tokenResponse.AccessToken.c
            Console.WriteLine(tokenResponse.ToString());
            
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            // call api
            var apiClient = new HttpClient(clientHandler);
            apiClient.SetBearerToken(tokenResponse.AccessToken);
            
            
            //apiClient.

            var response = await apiClient.GetAsync("https://localhost:6001/Paciente/Consulta/13145232242");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Deu certo????");
                Console.WriteLine( content );
                Console.WriteLine( JsonConvert.DeserializeObject(content) );
            }
        }
    }
}