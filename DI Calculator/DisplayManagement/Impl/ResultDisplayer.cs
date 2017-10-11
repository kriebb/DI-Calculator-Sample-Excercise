using System;
using System.Collections.Generic;
using ObscureWare.Console;

namespace DI_Calculator.DisplayManagement.Impl
{
    internal class ResultDisplayer : IDisplayer
    {
        private readonly IConsole _console;
        private readonly IOutputBuilderResult _outputBuilderResult;

        public ResultDisplayer(IConsole console, IOutputBuilderResult outputBuilderResult)
        {
            _console = console;
            _outputBuilderResult = outputBuilderResult;
        }
        public void Display(string origin, object result)
        {
            _console.WriteLine(_outputBuilderResult.Generate(origin,result));
            _console.ReadKey();
        }
    }
}