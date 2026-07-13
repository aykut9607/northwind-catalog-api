using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result: IResult
    {
        public Result(bool success, string message) : this(success)//DRY olmaması için bu class ın tek parametreli constructor ını çağırdık 
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }//setter yapmıyoruz zaten consructor da set edicez. return new Result(true,"Ürün eklendi"); gibi kullancaz.
        public string Message { get; }
    
    }
}
