// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        public static IEnumerable<Client> Clients =>
           new List<Client>
           {
                    new Client
                    {
                         ClientName = "Client Application2",
                         ClientId = "client",
                         AllowedGrantTypes = GrantTypes.ClientCredentials,
                         ClientSecrets = { new Secret("secret".Sha256()) },
                         AllowedScopes = { "api1" }
                            }
           };
        public static IEnumerable<ApiResource> Apis =>
          new List<ApiResource>
          {
                new ApiResource("api1","My API")
                {

                    UserClaims =
                {
                    JwtClaimTypes.Audience
                },
                     Scopes = new List<string>
                    {
                          "api1"
                    },
                }
          };
       

    
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }
        public static IEnumerable<IdentityServer4.Models.ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("api1", "My API")
            };
        }
    }
}