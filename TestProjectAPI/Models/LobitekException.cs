using System.Diagnostics.CodeAnalysis;

namespace TestProjectAPI.Models
{
    public class LobitekException : Exception
    {
        public LobitekException()
        {
            
        }
        public LobitekException(int statusCode, string message, string exceptionMessage)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.ExceptionMessage = exceptionMessage;
        }
        [DisallowNull]
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? ExceptionMessage { get; set; }


    }
}
