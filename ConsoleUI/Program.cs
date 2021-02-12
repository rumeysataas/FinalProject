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
           ProductJoinMethod();
        }

        private static void ProductJoinMethod()
        {
            ProductManager product = new ProductManager(new EfProductDal());
            var result = product.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ProductName + " : " + item.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
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
            foreach (var product in productManager.GetAll().Data)
            {

                Console.WriteLine(product.ProductName);

            }
            Console.WriteLine("*********************Category Id ye göre listelendi.********************");
            foreach (var product in productManager.GetAllByCategoryId(5).Data)
            {

                Console.WriteLine(product.ProductName);

            }
            Console.WriteLine("********************Fiyat aralığına göre listelendi.*******************");
            foreach (var product in productManager.GetByUnitPrice(3, 6).Data)
            {

                Console.WriteLine(product.ProductName);

            }
        }
    }
}
