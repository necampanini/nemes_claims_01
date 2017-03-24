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

        private static void CheckNewClaimsUsage()
        {
            ClaimsPrincipal currentClaimsPrincipal = Thread.CurrentPrincipal
                as ClaimsPrincipal;

            //now have access to all extra methods/props built in claimsPrincipal

            //can enumerate through the claims collections in the principal
            //object, find a specific claim using Linq, etc

            Claim nameClaim = currentClaimsPrincipal.FindFirst(ClaimTypes.Name);
            Console.WriteLine(nameClaim.Value);

            //can use .HasClaim to check fit he claims collection includes
            //a specific claim you're looking for

            //can also query the identities of the ClaimsPrincipal
            foreach (ClaimsIdentity ci in currentClaimsPrincipal.Identities)
            {
                Console.WriteLine(ci.Name);
            }

            //Thread.CurrentPrincipal as ClaimsPrincipal so common, just do
            ClaimsPrincipal currentClaimsPrincipal2 = ClaimsPrincipal.Current;
            //throws exception if the concrete IPrincipal type is not
            //ClaimsPrinciapl for whatever reason   
        }

        private static void CheckCompatibility()
        {
            //check compatibility of older principal based code

            IPrincipal currentPrincipal = Thread.CurrentPrincipal;

            //was original the ClaimType.Name
            Console.WriteLine(currentPrincipal.Identity.Name);
            //we changed the claimsIdentity ctor to specify name 
            //to be of type ClaimTypes.Email, and this verified that

            Console.WriteLine(currentPrincipal.IsInRole("Software Engineer"));
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
                claimCollection, "my pretend auth type",
                ClaimTypes.Email, ClaimTypes.Role);

            Console.WriteLine("Claims Identity auth'd: " +
                claimsIdentity.IsAuthenticated);

            ClaimsPrincipal principal = new ClaimsPrincipal(
                claimsIdentity);

            Thread.CurrentPrincipal = principal;
        }
    }
}
