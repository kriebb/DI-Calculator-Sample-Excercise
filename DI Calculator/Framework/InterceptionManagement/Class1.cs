﻿using System;
using System.Collections.Generic;
using System.Drawing;
using ObscureWare.Console;

namespace DI_Calculator.Framework.InterceptionManagement
{
    using Microsoft.Practices.Unity.InterceptionExtension;

    internal class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        private readonly IConsole _console;

        public LoggingInterceptionBehavior(IConsole console)
        {
            _console = console;
        }
        public IMethodReturn Invoke(IMethodInvocation input,
            GetNextInterceptionBehaviorDelegate getNext)
        {
            // Before invoking the method on the original target.
            WriteLog(String.Format(
                "Invoking method {0} at {1}",
                input.MethodBase, DateTime.Now.ToLongTimeString()));

            // Invoke the next behavior in the chain.
            var result = getNext()(input, getNext);

            // After invoking the method on the original target.
            if (result.Exception != null)
            {
                WriteLog(String.Format(
                    "Method {0} threw exception {1} at {2}",
                    input.MethodBase, result.Exception.Message,
                    DateTime.Now.ToLongTimeString()));
            }
            else
            {
                WriteLog(String.Format(
                    "Method {0} returned {1} at {2}",
                    input.MethodBase, result.ReturnValue,
                    DateTime.Now.ToLongTimeString()));
            }

            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private void WriteLog(string message)
        {
            _console.WriteLine(message);
        }
    }
}
