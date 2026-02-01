using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Peerly.Gateway.Hosting.Auth;

public sealed class PeerlyJwtBearerEvents : JwtBearerEvents
{
    private readonly JwtBearerEvents _platformJwtBearerEvents;

    public PeerlyJwtBearerEvents(JwtBearerEvents platformJwtBearerEvents)
    {
        _platformJwtBearerEvents = platformJwtBearerEvents;
    }

    public override Task TokenValidated(TokenValidatedContext context)
    {
        return _platformJwtBearerEvents.TokenValidated(context);
    }
}
