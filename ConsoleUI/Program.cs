using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        //SOLİD
        static void Main(string[] args)
        {

            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            //kendi yazdığımız verilerden gerçek bir veritabanına bağlandık ve EntityFramework ile bunu sağladık.


            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAllByCategoryId(1))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
