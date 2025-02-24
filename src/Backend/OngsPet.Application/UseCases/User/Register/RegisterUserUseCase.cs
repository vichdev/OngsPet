using AutoMapper;
using OngsPet.Application.Services.Cryptography;
using OngsPet.Communication.Requests;
using OngsPet.Communication.Responses;
using OngsPet.Domain.Repositories;
using OngsPet.Domain.Repositories.User;
using OngsPet.Exceptions;
using OngsPet.Exceptions.ExceptionsBase;

namespace OngsPet.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {

        private readonly IUserWriteOnlyRepository _writeOnlyRepository;
        private readonly IUserReadOnlyRepository _readOnlyRepository;
        private readonly PasswordEncripter _passwordEncripter;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterUserUseCase(
            IUserWriteOnlyRepository writeOnlyRepository,
            IUserReadOnlyRepository readOnlyRepository,
            IUnitOfWork unitOfWork,
            PasswordEncripter passwordEncripter,
            IMapper mapper
            )
        {
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
            _unitOfWork = unitOfWork;
            _passwordEncripter = passwordEncripter;
            _mapper = mapper;
        }

        public async Task<ResponseRegisterUserDTO> Execute(RequestRegisterUserDTO request)
        {


            Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _passwordEncripter.Encrypt(request.Password);

            await _writeOnlyRepository.AddAsync(user);

            await _unitOfWork.Commit();

            return new ResponseRegisterUserDTO
            {
                Name = request.Name,
            };
        }

        private async Task Validate(RequestRegisterUserDTO request)
        {
            var validator = new RegisterUserDTOValidator();

            var result = validator.Validate(request);

            var emailExist = await _readOnlyRepository.ExistUserWithSameEmail(request.Email);

            if (emailExist)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourcesMessagesException.EMAIL_ALREADY_EXISTS));
            }

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
