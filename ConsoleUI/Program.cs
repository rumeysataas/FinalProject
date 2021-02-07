using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Microsoft.VisualBasic;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductManager productManager = new ProductManager(new EfProductDal());
            Console.WriteLine("************************Tüm ürün isimleri listelendi.*************************");
            foreach (var product in productManager.GetAll())
            {
             
                Console.WriteLine(product.ProductName);
               
            }
            Console.WriteLine("*********************Category Id ye göre listelendi.********************");
            foreach (var product in productManager.GetAllByCategoryId(5))
            {
                
                Console.WriteLine(product.ProductName);
               
            }
            Console.WriteLine("********************Fiyat aralığına göre listelendi.*******************");
            foreach (var product in productManager.GetByUnitPrice(3,6))
            {
               
                Console.WriteLine(product.ProductName);
                
            }
        }
    }
}
