using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService 
    {
        List<Customer> GetAll();
        Customer Get(string id);
        List<Customer> GetByCity(string city);
    }
}
