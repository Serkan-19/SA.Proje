﻿using System.Text.Json.Serialization;

namespace CommonTypesLayer.Utilities
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> ErrorMessage { get; set; }

        public static ApiResponse<T> Success(int statusCode, T data)
        {
            return new ApiResponse<T> { StatusCode = statusCode, Data = data };
        }
        public static ApiResponse<T> Success(int statusCode)
        {
            return new ApiResponse<T> { StatusCode = statusCode };
        }
        public static ApiResponse<T> Fail(int statusCode, string errorMessage)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                ErrorMessage = new List<string> { errorMessage }
            };
        }
        public static ApiResponse<T> Fail(int statusCode, List<string> errorMessage)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                ErrorMessage = errorMessage
            };
        }
    }
}

