using OngsPet.Communication.Requests;
using OngsPet.Communication.Responses;

namespace OngsPet.Application.UseCases.User.Register
{
    public interface IRegisterUserUseCase
    {
        Task<ResponseRegisterUserDTO> Execute(RequestRegisterUserDTO request);

    }
}
