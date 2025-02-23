using OngsPet.Communication.Requests;
using OngsPet.Communication.Responses;
using OngsPet.Exceptions.ExceptionsBase;

namespace OngsPet.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserDTO Execute(RequestRegisterUserDTO request)
        {

            Validate(request);

            return new ResponseRegisterUserDTO
            {
                Name = request.Name,
            };
        }

        private void Validate(RequestRegisterUserDTO request)
        {
            var validator = new RegisterUserDTOValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
