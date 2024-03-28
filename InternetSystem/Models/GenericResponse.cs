﻿namespace BackendBootcamp.Models
{
    public class GenericResponse<T>
    {
        public int statusCode { get; set; }
        public T? data { get; set; }
        public string? message { get; set; }
        public GenericResponse(string message, int statusCode, T data)
        {
            this.message = message;
            this.statusCode = statusCode;
            this.data = data;
        }
    }
}