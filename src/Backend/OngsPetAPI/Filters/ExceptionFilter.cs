using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OngsPet.Communication.Responses;
using OngsPet.Exceptions;
using OngsPet.Exceptions.ExceptionsBase;

namespace OngsPet.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {

            if (context.Exception is OngsPetException exception)
            {
                HandleException(context);
            }
            else
            {
                ThrowUnknowException(context);
            }
        }

        private void HandleException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException)
            {
                var exception = context.Exception as ErrorOnValidationException;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorDTO(exception.ErrorMessages));
            }
        }

        private void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorDTO(ResourcesMessagesException.UNKNOWN_ERROR));
        }
    }
}
