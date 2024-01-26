using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace FullCart.Infrastructure.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
