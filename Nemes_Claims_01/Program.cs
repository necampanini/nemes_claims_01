using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace Nemes_Claims_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();
            CheckCompatibility();

            Console.ReadLine();
        }

        private static void CheckCompatibility()
        {
            IPrincipal currentPrincipal = Thread.CurrentPrincipal;
            Console.WriteLine(currentPrincipal.Identity.Name);
        }

        private static void Setup()
        {
            // #AAA111 - note Id
            IList<Claim> claimCollection = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Nicky"),
                new Claim(ClaimTypes.Country, "USA"),
                new Claim(ClaimTypes.Gender, "M"),
                new Claim(ClaimTypes.Surname, "Campanini"),
                new Claim(ClaimTypes.Email, "necampanini@gmail.com"),
                new Claim(ClaimTypes.Role, "Software Engineer")
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claimCollection, "my pretend auth type");

            Console.WriteLine("Claims Identity auth'd: " +
                claimsIdentity.IsAuthenticated);

            ClaimsPrincipal principal = new ClaimsPrincipal(
                claimsIdentity);

            Thread.CurrentPrincipal = principal;
        }
    }
}
