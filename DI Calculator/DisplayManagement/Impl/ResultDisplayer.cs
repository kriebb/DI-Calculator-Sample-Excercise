using System;

namespace DI_Calculator.DisplayManagement.Impl
{
    internal class ResultDisplayer:IDisplayer
    {
        public void Display(string origin, int result)
        {
            Console.WriteLine(string.Format($"{origin}: result:{result}"));
            Console.ReadKey();
        }
    }
}