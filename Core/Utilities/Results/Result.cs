using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message) : this(success) // resultun iki parametreli const. tek parametreli const gönderirsek iki const. da çalışır.
        {
            Message = message;
        }

        //overloading
        public Result(bool success)
        {
            Success = success;
        }

        //sadece get oldukları için set edilememleri lazım fakat constructor içerisinde set edilebilirler.
        public bool Success { get; }
        public string Message { get; }

    }
}
