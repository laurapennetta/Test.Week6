using System;

namespace Test.Week6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cicle = true;
            while (cicle)
            {
                cicle = InsuranceManagment.Menu();
            }
        }
    }
}
