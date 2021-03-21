using System;
using System.Collections.Generic;
using System.Text;

namespace Cypher
{
    class Rectangle : Shape
    {
        private double Height { get; set; }
        private double Width { get; set; }
        public Rectangle(double Width, double Height)
        {
            this.Height = Height;
            this.Width = Width;
        }

        public override double Area()
        {
            return Height * Width;
        }
    }
}
