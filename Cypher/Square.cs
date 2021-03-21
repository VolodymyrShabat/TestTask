using System;
using System.Collections.Generic;
using System.Text;

namespace Cypher
{
    class Square : Shape
    {
        private double Side { get; set; }
        public Square(double Side)
        {
            this.Side = Side;
        }

        public override double Area()
        {
            return Side * Side;
        }
    }
}
