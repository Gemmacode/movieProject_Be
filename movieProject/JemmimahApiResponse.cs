﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{

    public class JemmimahApiResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public object Data { get; set; }

        public JemmimahApiResponse(string message = null)
        {
            Succeeded = true;
            Message = message;
        }

        public static JemmimahApiResponse Success(object data)
        {
            return new JemmimahApiResponse { Message = "Success", Data = data };
        }

        public static JemmimahApiResponse Failed(object data, string message = "Failure", List<string> errors = null)
        {
            return new JemmimahApiResponse { Succeeded = false, Data = data, Message = message, Errors = errors };
        }
    }

    public class ApiResponse<T> : JemmimahApiResponse
    {
        public T Data { get; set; }
        public ApiResponse() { }


        public static ApiResponse<T> Success(T data, string message)
        {
            return new ApiResponse<T> { Succeeded = true, Data = data, Message = message };
        }


        public static ApiResponse<T> Failed(T data, string message = null, List<string> errors = null)
        {
            return new ApiResponse<T> { Succeeded = false, Data = data, Message = message, Errors = errors };
        }


        public ApiResponse(T data, string message = null)
        {
            Succeeded = true;
            message = message;
            data = data;
        }



    }
}
