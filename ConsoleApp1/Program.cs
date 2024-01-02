using Microsoft.VisualBasic;
using System.Globalization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Print();

            // Lets switch our language
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            Print();

            // Lets switch our language again
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-gb");
            Print();
        }

        static void Print()
        {
            Console.WriteLine("You say '{0}' in {1}", LocalizationTest.hello, Thread.CurrentThread.CurrentUICulture);
        }
    }
}
