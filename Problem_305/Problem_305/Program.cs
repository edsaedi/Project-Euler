using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_305
{
    class StringThing
    {
        class Node
        {
            public char Value;
            public Node Next;
        }

        Node head;
        Node tail;
        double Count;

        public void Append(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                this.Append(value[i]);
            }
        }

        public void Append(char value)
        {
            if (head == null)
            {
                head = new Node() { Value = value };
                tail = head;
            }
            else
            {
                tail.Next = new Node() { Value = value };
                tail = tail.Next;
            }
            Count++;
        }

        public string Substring(double index, int length)
        {
            Node curr = head;
            for (double i = 0; i < index; i++)
            {
                curr = curr.Next;
                if (curr == null)
                {
                    throw new Exception("string not big enough");
                }
            }

            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                temp.Append(curr.Value);
                curr = curr.Next;
                if (curr == null)
                {
                    throw new Exception("string not big enough");
                }
            }

            return temp.ToString();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            StringThing mainString = new StringThing();
            //building a string from 1-4 billion

            double size = 1000000;
            double[] powersOf3 = new double[13];
            for (int i = 0; i < powersOf3.Length; i++)
            {
                powersOf3[i] = Math.Pow(3, i + 1);
            }

            for (double i = 1; i < size; i++)
            {
                mainString.Append(i.ToString());
            }

            double Sum = 0;
            for (int i = 0; i < powersOf3.Length; i++)
            {
                double temp = Function(powersOf3[i], mainString, size);
                Sum += temp;
            }

            Console.WriteLine(Sum);
            Console.ReadKey();
        }

        static double Function(double number, StringThing S, double size)
        {
            double Count = 0;
            for (double i = 0; i < size; i++)
            {
                string temp = number.ToString();
                string gen = S.Substring(i, temp.Length);
                if (gen == temp)
                {
                    Count++;
                }
                if (Count == number)
                {
                    return i;
                }
            }
            throw new Exception("size not big enough");
        }
    }
}
