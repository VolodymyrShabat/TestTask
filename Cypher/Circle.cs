using System;
using System.Collections.Generic;
using System.Text;

namespace Cypher
{
    class Circle : Shape
    {
        private double Radius { get; set; }
        public Circle(double Radius)
        {
            this.Radius = Radius;
        }

        public override double Area()
        {
            return Radius * Radius * Math.PI;
        }
    }
}
