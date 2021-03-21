using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cypher
{
    class Program
    {
        static void Main(string[] args)
        {

            var side = 1.1234D;
            var radius = 1.1234D;
            var @base = 5D;
            var height = 2D;
            Shape s = (new Square(side));

            var shapes = new List<Shape>{ new Square(side),new Triangle(@base, height),
            new Circle(radius)
                 };
            shapes.Sort();
            Console.WriteLine(Encode(String.Empty,2));
        }
        public static string Encode(string s, int n)
        {
            if (n < 2)
            {
                throw new Exception("Number of rails should be >= 2");
            }
            if (n >= s.Length)
                return s;
            List<Tuple<int, string>> dict = new List<Tuple<int, string>>();
            string returned = string.Empty;
            if (s==String.Empty)
            {
                return String.Empty;
            }
            else
            {

                int counter = 0 ;
                string orientation = "down";
                foreach (var letter in s.ToCharArray())
                {
                    if(counter==0)
                    {
                        dict.Add(Tuple.Create(counter, letter.ToString()));
                        orientation = "down";
                        counter++;
                    }
                    else 
                        if(counter==n-1)
                        {
                            dict.Add(Tuple.Create(counter, letter.ToString()));
                            orientation = "up";
                            counter--;
                        }
                    else
                    {
                        if(orientation=="down")
                        {
                            dict.Add(Tuple.Create(counter, letter.ToString()));
                            counter++;
                        }
                        if (orientation == "up")
                        {
                            dict.Add(Tuple.Create(counter, letter.ToString()));
                            counter--;
                        }
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    foreach (var item in dict.Where(x => x.Item1 == i).Select(x => x.Item2.ToString()))
                    {
                        returned += item;
                    }
                }
                return returned;
            }
            

           

        }

        public static string Decode(string s, int n)
        {
            if(n<2)
            {
                throw new Exception("Number of rails should be >= 2");
            }
            if (n >= s.Length)
                return s;
            int[] arr = new int[n];
            arr[0] = (s.Length - 1 + (2 * n - 2)) / (2 * n - 2);
            arr[n - 1] = (s.Length + n - 2) / (2 * n - 2);
            int temp = 2 * n - 2;

            //отримаємо кількість елементів на кожному рівні 
            for (int i = 1; i < n-1; i++)
            {
                temp -= 2;
                arr[i] = ((s.Length - (i + 1) + (2 * n - 2)) / (2 * n - 2)) + ((s.Length - (i +1+ temp) + (2 * n- 2)) / (2 * n - 2));
            }

            //групуємо букви по рівнях
            string returned = string.Empty;
            StringBuilder sb = new StringBuilder(s);
            string[] array = new string[n];
            for (int i = 0; i < n; i++)
            {
                string tempArr =string.Empty;
                for (int j = 0; j < arr[i]; j++)
                {
                    if(sb.ToString()!=string.Empty)
                    {
                        tempArr += sb[0].ToString();
                        sb.Remove(0, 1);
                    }
                    
                }
                array[i] = tempArr;
            }



            //формуємо результат
            int counter = 0;
            while(s.Length- counter>0)
            {
                for (int i = 0; i < n; i++)
                {
                    if(array[i]!=String.Empty)
                    {
                        returned += array[i][0];
                        sb.Clear();
                        sb.Append(array[i]);
                        sb.Remove(0, 1);
                        array[i] = sb.ToString();
                        counter++;
                        
                    }
                    
                }
                for (int i = n-2; i >0; i--)
                {
                    if (array[i] != String.Empty)
                    {
                        returned += array[i][0];
                        sb.Clear();
                        sb.Append(array[i]);
                        sb.Remove(0, 1);
                        array[i] = sb.ToString();
                        counter++;
                    }
                }
            }
            return returned;
        }
    }
}
