using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSample.Lib.Models
{
    public class Model : IModel
    {
        public double Calculate(double operand)
        {
            return operand * operand;
        }
    }
}
