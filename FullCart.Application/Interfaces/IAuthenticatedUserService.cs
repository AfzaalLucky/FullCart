using System;
using System.Linq;

namespace FullCart.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
