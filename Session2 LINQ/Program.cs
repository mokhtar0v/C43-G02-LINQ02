using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace Session2_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Element Operators
            //1. Get first Product out of Stock 
            var rese01 = ListGenerator.ProductList.First(p => p.UnitsInStock == 0);
            Console.WriteLine(rese01);
            Console.WriteLine("//////");

            //2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            var rese02 = ListGenerator.ProductList.FirstOrDefault(p => p.UnitPrice > 1000, null);
            Console.WriteLine(rese02);
            Console.WriteLine("//////");

            //3. Retrieve the second number greater than 5 
            int[] ArrE = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var rese03 = ArrE.Where(p => p > 5).Skip(count: 1).First();
            Console.WriteLine(rese03);
            Console.WriteLine("//////");
            #endregion

            #region LINQ - Aggregate Operators
            //1. Uses Count to get the number of odd numbers in the array
            int[] ArrA = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var resa01 = ArrA.Count(a => a % 2 != 0);
            Console.WriteLine(resa01);
            Console.WriteLine("//////");

            //var resa02 = ListGenerator.CustomerList.Count(c => c.Orders != null);
            var resa02 = from c in ListGenerator.CustomerList
                         select c.Orders.Count(c => c != null);
            foreach(var item in resa02)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("//////");

            //3. Return a list of categories and how many products each has
            var resa03 = ListGenerator.ProductList.GroupBy(p => p.Category).Select(p => new { cat = p.Key, count = p.Count() });
            foreach(var item in resa03)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("//////");

            //4. Get the total of the numbers in an array.
            int[] ArrA02 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var resa04 = ArrA02.Sum();
            Console.WriteLine(resa04);
            Console.WriteLine("//////");

            //5.Get the total number of characters of all words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            string[] stra = File.ReadAllLines("E:\\Temp\\ASP.NET\\C#\\LINQ\\Session2 LINQ\\Session2 LINQ\\Session2 LINQ\\bin\\Debug\\net8.0\\dictionary_english.txt");
            var resa05 = stra.Sum(w => w.Length);
            Console.WriteLine(resa05);
            Console.WriteLine("//////");

            //6.Get the length of the shortest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            //var resa06 = stra.OrderBy(w => w.Length).First();
            var resa06 = stra.Min(w => w.Length);
            Console.WriteLine(resa06);
            Console.WriteLine("//////");

            //7.Get the length of the longest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            var resa07 = stra.Max(w => w.Length);
            Console.WriteLine(resa07);
            Console.WriteLine("//////");

            //8.Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            var resa08 = stra.Average(w => w.Length);
            Console.WriteLine(resa08);
            Console.WriteLine("//////");

            //9. Get the total units in stock for each product category.
            //var resa09 = ListGenerator.ProductList.GroupBy(p => p.Category).Select(p => p.Sum(p => p.UnitsInStock));
            var resa09 = ListGenerator.ProductList.GroupBy(p => p.Category).Select(p => new { Catrgory = p.Key, InStock = p.Sum(p => p.UnitsInStock) });
            foreach (var item in resa09)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("//////");

            //10.Get the cheapest price among each category's products
            var resa10 = ListGenerator.ProductList.GroupBy(p => p.Category).Select(p => new { Catrgory = p.Key, Cheapest = p.Min(p => p.UnitPrice) });
            foreach (var item in resa10)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("//////");

            //11.Get the products with the cheapest price in each category(Use Let)
            var resa11 = from p in ListGenerator.ProductList
                         group p by p.Category into pp
                         let min = pp.Min(p => p.UnitPrice)
                         from p in pp
                         where p.UnitPrice == min
                         select new { p.Category, p.UnitPrice };
            foreach(var item in resa11)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("//////");

            //12. Get the most expensive price among each category's products.
            var resa12 = ListGenerator.ProductList.GroupBy(p => p.Category).Select(p => new { Catrgory = p.Key, mostExpansive = p.Max(p => p.UnitPrice) });
            foreach (var item in resa12)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("//////");
            //14. Get the average price of each category's products.
            var resa14 = ListGenerator.ProductList.GroupBy(p => p.Category).Select(p => new { Catrgory = p.Key, Average = p.Average(p => p.UnitPrice) });
            foreach (var item in resa14)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("//////");
            #endregion
        }
    }
}
