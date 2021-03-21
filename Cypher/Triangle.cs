using System;
using System.Collections.Generic;
using System.Text;

namespace Cypher
{
    class Triangle : Shape
    {
        private double Height { get; set; }
        private double Base { get; set; }
        public Triangle(double Base, double Height)
        {
            this.Base = Base;
            this.Height = Height;
        }

        public override double Area()
        {
            return (Height * Base )/2;
        }
    }
}
