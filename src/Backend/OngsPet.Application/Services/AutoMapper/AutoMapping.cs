using AutoMapper;
using OngsPet.Communication.Requests;
using OngsPet.Domain.Entities;

namespace OngsPet.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterUserDTO, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }

        private void DomainToResponse()
        {

        }
    }
}
