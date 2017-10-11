using System;
using System.Collections.Generic;
using DI_Calculator.Framework.SettingsManagement;
using ObscureWare.Console;

namespace DI_Calculator.DisplayManagement.Impl
{
    internal class ResultDisplayer : IDisplayer
    {
        private readonly IConsole _console;
        private readonly IOutputBuilderResult _outputBuilderResult;
        private readonly ISettings _settings;

        public ResultDisplayer(IConsole console, IOutputBuilderResult outputBuilderResult,ISettings settings)
        {
            _console = console;
            _outputBuilderResult = outputBuilderResult;
            _settings = settings;
        }
        public void Display(string origin, object result)
        {
            _console.WriteLine(_outputBuilderResult.Generate(_settings.UserName, origin,result));
            _console.ReadKey();
        }
    }
}