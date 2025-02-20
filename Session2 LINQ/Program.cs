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
            var rese03 = ArrE.Where(p => p < 5).Skip(1).First();
            #endregion
        }
    }
}
