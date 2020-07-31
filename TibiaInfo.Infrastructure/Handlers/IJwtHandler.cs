using System;
using TibiaInfo.Infrastructure.DTO;

namespace TibiaInfo.Infrastructure.Handlers
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}