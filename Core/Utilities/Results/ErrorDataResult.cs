using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data, bool success) : base(data, false)
        {
        }


        //burdan aşağısını genelde kullanılmaz kabul ediyoruz
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        //default dataya karşılı geliyor 
        public ErrorDataResult() : base(default, false)
        {

        }

        T Data { get; }
    }
}
