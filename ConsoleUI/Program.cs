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
            // ProductMethod();
            // CategoryMethod();
            ProductManager product = new ProductManager(new EfProductDal());
            foreach (var item in product.GetProductDetails())
            {
                Console.WriteLine(item.ProductName+" : "+item.CategoryName);
            }
        }

        private static void CategoryMethod()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductMethod()
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
            foreach (var product in productManager.GetByUnitPrice(3, 6))
            {

                Console.WriteLine(product.ProductName);

            }
        }
    }
}
