using BuberDinner.Application.Autentication.Common;
using BuberDinner.Application.Autentication.Login;
using BuberDinner.Application.Autentication.Register;
using BuberDinner.Contracts;
using Mapster;

namespace BuberDinner.Api.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginQuery, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User)
            .Map(dest => dest.Id, src => src.User.Id.Value);
    }
}
