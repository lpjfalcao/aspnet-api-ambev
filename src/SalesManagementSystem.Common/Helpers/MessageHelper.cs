using SalesManagementSystem.Common.Enums;
using ValidationFailure = FluentValidation.Results.ValidationFailure;

namespace SalesManagementSystem.Common.Helpers
{
    public class MessageHelper<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public List<string> ValidationErrors { get; set; }
       
        public void Ok(T data)
        {
            Data = data;
            Success = true;
            StatusCode = (int)StatusCodeEnum.Ok;
        }

        public void NotFound(string message)
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.NotFound;
            Message = message;
        }

        public void BadRequest(Exception ex, List<ValidationFailure> errors)
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.BadRequest;
            Message = ex.Message;
            ValidationErrors = errors?.Select(v => v.ErrorMessage).ToList() ?? new List<string>(); ;
        }
        public void BadRequest(Exception ex)
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.BadRequest;
            Message = ex.Message;
        }

        public void Error(Exception ex)
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.InternalServerError;
            Message = ex.Message;
            StackTrace = ex.StackTrace;
        }

        public void Created(T data)
        {
            Data = data;
            Success = true;
            StatusCode = (int)StatusCodeEnum.Created;
            Message = "Recurso cadastrado com sucesso";
        }
    }
    public class MessageHelper
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public List<string> ValidationErrors { get; set; }

        public void Ok()
        {
            Success = true;
            StatusCode = (int)StatusCodeEnum.Ok;
        }

        public void NotFound(string message)
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.NotFound;
            Message = message;
        }

        public void BadRequest(Exception ex)
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.BadRequest;
            Message = ex.Message;
        }

        public void BadRequest(Exception ex, List<ValidationFailure> errors)
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.BadRequest;
            Message = ex.Message;
            ValidationErrors = errors?.Select(v => v.ErrorMessage).ToList() ?? new List<string>();
        }

        public void Error(Exception ex)
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.InternalServerError;
            Message = ex.Message;
            StackTrace = ex.StackTrace;
        }
    }
}
