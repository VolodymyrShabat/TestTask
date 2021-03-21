using System;
using System.Collections.Generic;
using System.Text;

namespace Cypher
{
    abstract class Shape:IComparable
    {
         
        public Shape()
        {

        }

        public int CompareTo(object obj)
        {
            var shape = obj as Shape;
            if(shape == null)
            {
                throw new Exception("Wrong data type");
            }
            else
            {
                return this.Area().CompareTo(shape.Area());
            }
        }

        public abstract double Area();

    }
}
