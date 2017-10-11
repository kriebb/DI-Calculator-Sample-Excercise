﻿using System;

namespace DI_Calculator.CalculationManagement.Impl
{
    internal class OpenForExtensionCalculator : ICalculator
    {
        private readonly IOperationFactory _operationFactory;

        public OpenForExtensionCalculator(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }
        public int Calculate(string operand, int x, int y)
        {
            var operation = _operationFactory.Create(operand);
            var result = operation.Evaluate(x, y);
            return result;
        }

        private static int OperationFactory(string operation, int x, int y)
        {
            int result;
            switch (operation)
            {
                case "*":
                    result = Multiply(x, y);
                    break;
                case "+":
                    result = Add(x, y);
                    break;
                default:
                    throw new ArgumentException($"We ondersteunen niet de operatie: {operation} enkel maar de operatie * of +");
            }
            return result;
        }

        private static int Multiply(int x, int y)
        {
            return x * y;
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }
    }
}