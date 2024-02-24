using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Contracts.Results
{
    public class OperationResult
    {
        public bool IsSucceeded { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSucceeded = false;
        }

        public OperationResult Succeeded()
        {
            IsSucceeded = true;
            Message = "Operation was succeeded";

            return this;
        }

        public OperationResult Succeeded(string _message)
        {
            IsSucceeded = true;
            Message = _message;

            return this;
        }

        public OperationResult Succeeded(int _code, string _message)
        {
            IsSucceeded = true;
            Message = _message;
            Code = _code;

            return this;
        }

        public OperationResult Failed(string _message)
        {
            IsSucceeded = false;
            Message = _message;

            return this;
        }

        public OperationResult Failed(int _Code, string _message)
        {
            IsSucceeded = false;
            Message = _message;
            Code = _Code;

            return this;
        }
    }
    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }

        public OperationResult<T> Succeeded(T _data)
        {
            IsSucceeded = true;
            Message = "Operation was succeeded";
            Data = _data;

            return this;
        }
        public OperationResult<T> Succeeded(string _Message, T _Data)
        {
            IsSucceeded = true;
            Message = _Message;
            Data = _Data;

            return this;
        }

        public OperationResult<T> Succeeded(int _Code, string _Message, T _Data)
        {
            IsSucceeded = true;
            Message = _Message;
            Code = _Code;
            Data = _Data;

            return this;
        }

        public OperationResult<T> Failed(string _Message)
        {
            IsSucceeded = false;
            Message = _Message;

            return this;
        }

        public OperationResult<T> Failed(int _Code, string _Message)
        {
            IsSucceeded = false;
            Message = _Message;
            Code = _Code;

            return this;
        }
    }
}
