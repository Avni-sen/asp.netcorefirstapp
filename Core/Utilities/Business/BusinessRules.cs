using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            //logics içine , ile Iresult tipinde istedğimiz kadar değer ekleyebiliyoruz.. --> params sayesinde.
            foreach (var logic in logics)
            {
                if (logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
