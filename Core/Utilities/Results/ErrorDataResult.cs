using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>, IDataResult<T>
    {

        public ErrorDataResult(T data, bool success, string message) : base(data, true, message)
        {

        }
        public ErrorDataResult(T data, bool success) : base(data, true)
        {

        }

        public ErrorDataResult(T data) : base(data, true)
        {

        }

        public ErrorDataResult() : base(default, true)
        {

        }
    }
}
