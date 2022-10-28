using System.Security.Claims;
using Test.Models;

namespace UsersControl.Extensions;

public static class ClaimExtension
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        var result = new List<Claim>
        {
            new(ClaimTypes.Name, user.Name),
        };
        return result;
    }
}