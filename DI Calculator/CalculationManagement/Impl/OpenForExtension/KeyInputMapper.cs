using System;
using System.Collections.Generic;
using DI_Calculator.Shared;

namespace DI_Calculator.CalculationManagement.Impl.OpenForExtension
{
    internal class KeyInputMapper : IKeyInputMapper
    {
        private IDictionary<string, string> _dictionary;

        public KeyInputMapper()
        {
            _dictionary = new Dictionary<string, string>();
            _dictionary.Add(Defines.Sum, Defines.Sum);
            _dictionary.Add(Defines.Substraction, Defines.Substraction);
            _dictionary.Add(Defines.Division,Defines.Division);
            _dictionary.Add(Defines.Multiplication,Defines.Multiplication);
            _dictionary.Add("x", Defines.Multiplication);
            _dictionary.Add(".", Defines.Multiplication);
        }
        public string Map(string value)
        {
            _dictionary.TryGetValue(value, out string mappedValue);
            return mappedValue;
        }
    }
}