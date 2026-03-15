using System;

namespace Auth.Models.DTOs;

public class ApiResponseDto<T>
{
     public bool Success { get; set; }
    public  string? Message { get; set; }
    public static string? singMessage { get; set; }
    public T? Data { get; set; }
    public IEnumerable<string>?  Errors { get; set; }

     public static ApiResponseDto<T> SuccessResponse(T data, string message)
    {
        return new ApiResponseDto<T>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    public static ApiResponseDto<T> FailureResponse(IEnumerable<string> errors, string message)
    {
        return new ApiResponseDto<T>
        {
            Success = false,
            Message = message,
            Errors = errors
        };
    }

}
