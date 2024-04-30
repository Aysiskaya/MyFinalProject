using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[]args)
        {
            // CategoryTest();
           // CategoryTestt();
           //IoC
        }

        private static void CategoryTestt()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            var result = productManager.GetProductDetails();

            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            Console.ReadLine();
        }

       // private static void CategoryTest()
        //{
         //   CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
         //   foreach (var category in categoryManager.GetAll().Data)
         //   {
         //       Console.WriteLine(category.CategoryName);
         //   }
          //  Console.ReadLine();
        //}
    }
}
