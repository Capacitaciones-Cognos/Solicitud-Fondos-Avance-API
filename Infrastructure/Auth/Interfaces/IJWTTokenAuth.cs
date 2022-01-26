using Solicitud_Fondos_Avance_API.Dtos.commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Infrastructure.Interfaces.Auth
{
    public interface IJWTTokenAuth
    {
        string authenticate(AuthenticateDto authenticateDto);

    }
}
