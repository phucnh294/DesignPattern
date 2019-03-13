using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

//Ensure a class has only one instance and provide a global point of
//access to it
namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator.Insctance().valueOne = 10;
            Calculator.Insctance().valueTwo = 5;
            
            Console.WriteLine("Add : " + Calculator.Insctance().Add());
            Console.WriteLine("Sub : " + Calculator.Insctance().Subtract());
            Console.WriteLine("Multi : " + Calculator.Insctance().Multiple());
            Console.WriteLine("Devide : " + Calculator.Insctance().Divide());

            Console.ReadKey();
        }
    }

    public class Calculator
    {
       private Calculator() { }

        private static readonly Calculator instance = new Calculator();

        public static Calculator Insctance()
        {
//            if (instance == null)
//            {
//                instance= new Calculator();
//            }
            return instance;
        }
        public int valueOne { get; set; }
        public int valueTwo { get; set; }

        public int Add()
        {
            return valueOne + valueTwo;
        }

        public int Subtract()
        {
            return valueOne - valueTwo;
        }

        public int Multiple()
        {
            return valueOne*valueTwo;
        }

        public int Divide()
        {
            return valueOne/valueTwo;
        }
    }
}
