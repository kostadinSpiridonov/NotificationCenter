using System.Linq;
using System.Security.Claims;

namespace NotificationCenter.Web.Services.Auth
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetClientId(this ClaimsPrincipal claimsPrincipal)
        {
            string clientId = claimsPrincipal.Claims
                .Where(c => c.Type == NotificationClaimTypes.ClientId)
                .Select(c => c.Value)
                .SingleOrDefault();

            return int.Parse(clientId);
        }
    }
}
