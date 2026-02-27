using System;

namespace MODELS.Models.ViewsModel;

public class ResponseModel<T>
{
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

         public static ResponseModel<T> Success(T data, string? message = null)
    {
        return new ResponseModel<T>
        {
            IsSuccess = true,
            Data = data,
            Message = message
        };
    }

    public static ResponseModel<T> Failure(string message)
    {
        return new ResponseModel<T>
        {
            IsSuccess = false,
            Message = message
        };
    }

}
