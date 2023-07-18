

namespace FinalProject.Application.Common.Models.Errors
{//Hata aldığımızda kullanıcıya ApiErrorDto dönücez.
    public class ApiErrorDto
    {
        public string Message { get; set; } // There are one or more errors occurred.
        public List<ErrorDto> Errors { get; set; }

        public ApiErrorDto()
        {
            Errors = new List<ErrorDto>();
        }

        public ApiErrorDto(string message)
        {
            Message = message;
        }

        public ApiErrorDto(string message, List<ErrorDto> errors)
        {
            Message = message;

            Errors = errors;
        }

    }
}

