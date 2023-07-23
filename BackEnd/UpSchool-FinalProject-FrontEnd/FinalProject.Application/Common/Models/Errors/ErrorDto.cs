namespace FinalProject.Application.Common.Models.Errors
{
    public class ErrorDto
    {
        public string PropertyName { get; set; }//Email adress
        public List<string> ErrorMessages { get; set; }//Email adress doğru formatta değil

        public ErrorDto(string propertyName, List<string> errorMessages)
        {
            PropertyName = propertyName;

            ErrorMessages = errorMessages;
        }
  
    }
}
