using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result, IResult
    {
        public ErrorResult(bool success, string message) : base(false, message)
        {

        }
        public ErrorResult(bool success) : base(false)
        {

        }


        public bool Success { get; }
        public string Message { get; }
    }
}
