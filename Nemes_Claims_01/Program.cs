using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Nemes_Claims_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Claim claim = new Claim("Name", "Nicky");
            //strings bad, there are standard claim types

            Claim newClaim = new Claim(ClaimTypes.Country, "USA");

            //#AAA111 -- note identifier :)
            IList<Claim> claimCollection = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Nicky"),
                new Claim(ClaimTypes.Country, "USA"),
                new Claim(ClaimTypes.Gender, "M"),
                new Claim(ClaimTypes.Surname, "Campanini"),
                new Claim(ClaimTypes.Email, "necampanini@gmail.com"),
                new Claim(ClaimTypes.Role, "Software Engineer")
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimCollection);

            var authenticatedClaimsIdentity = new ClaimsIdentity(
                claimCollection, "my pretend e-commerce website");
            Console.WriteLine("claims identity is authenticated: " + claimsIdentity.IsAuthenticated);
            Console.WriteLine("auth'd claims Identity is authenticated: " + authenticatedClaimsIdentity.IsAuthenticated);
            Console.ReadKey();
        }
    }
}
