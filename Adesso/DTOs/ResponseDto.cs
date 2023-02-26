using System;
using System.Text.Json.Serialization;

namespace Adesso.DTOs
{
    public class ResponseDto<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public T? Data { get; set; }

        public static ResponseDto<T> Create(T data)
        {
            return new DTOs.ResponseDto<T>
            {
                IsSuccess = true,
                Data = data
            };
        }

        public static ResponseDto<object> Fail(int statusCode, string errorMessage)
        {
            return new DTOs.ResponseDto<object>
            {
                IsSuccess = false,
                ErrorMessage = errorMessage,
                StatusCode = statusCode,
                Data = null
            };
        }
        public static ResponseDto<object> Succes(int statusCode, object? data = null)
        {
            return new DTOs.ResponseDto<object>
            {
                IsSuccess = true,
                ErrorMessage = "",
                StatusCode = statusCode,
                Data = data
            };
        }
        public static ResponseDto<List<T>> ListResponse(int statusCode, List<T> data)
        {
            return new DTOs.ResponseDto<List<T>>
            {
                IsSuccess = true,
                StatusCode = statusCode,
                Data = data
            };
        }
    }
}
