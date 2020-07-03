using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;
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
                new ApiResource("reservation", "Reservation Service"),
                new ApiResource("employees", "Employees Service"),
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }



        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
               new Client
               {
                    ClientId = "company-employee",
                    ClientSecrets = new [] { new Secret("codemazesecret".Sha512()) },
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes =
                   { 
                       IdentityServerConstants.StandardScopes.OpenId,
                       "reservation",
                       "employees"
                   }
                }
            };
        }

    }
}
