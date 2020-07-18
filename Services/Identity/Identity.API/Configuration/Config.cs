using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;
using IdentityServer4;

namespace Identity.API.Configuration
{
    public class Config
    {

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("reservation", "Reservation Service")
                {
                    Scopes={"reservation" }
                },
                new ApiResource("employees", "Employees Service"),
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("reservation", new[]{"sub"})
            };
        }



        public static IEnumerable<Client> GetClients(Dictionary<string,string> clientsUrl)
        {
            return new List<Client>
            {
               new Client
                {
                    ClientId = "js",
                    ClientName = "Room Reservation SPA",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =           { $"{clientsUrl["Spa"]}/redirect.html" },
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"{clientsUrl["Spa"]}/" },
                    AllowedCorsOrigins =     { $"{clientsUrl["Spa"]}" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },
                },
               new Client
                {
                    ClientId = "insomnia",
                    ClientName = "Room Reservation SPA",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =           { $"https://insomnia.rest" },
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"https://insomnia.rest" },
                    AllowedCorsOrigins =     { $"https://insomnia.rest" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },
                },

               new Client
                {
                    ClientId = "client_id_js",
                    ClientName = "Room Reservation SPA",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =           { $"https://localhost:44345/Home/SignIn" },
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"https://localhost:44345" },
                    AllowedCorsOrigins =     { $"https://localhost:44345" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "reservation",
                        "orders",
                        "basket",
                        "locations",
                        "marketing",
                        "webshoppingagg",
                        "orders.signalrhub",
                        "webhooks"
                    }
                },
            };
        }

    }
}
