using System.Security.Claims;

namespace InterviewServer.Configuration
{
    internal static class HttpContextExtensions
    {
        public static long GetUserId(this ClaimsPrincipal claims)
        { 
            return long.Parse(claims.FindFirstValue("Id"));
        }
    }
}
