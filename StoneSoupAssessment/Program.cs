using StoneSoupAssessment.Exceptions;
using StoneSoupAssessment.LinkedList;
using StoneSoupAssessment.LinkedList.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneSoupAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            IStringCalculator sc = new StringCalculator();

            Console.WriteLine(sc.Add(string.Empty));
            Console.WriteLine(sc.Add("10"));
            Console.WriteLine(sc.Add("10,2"));
            Console.WriteLine(sc.Add("1, 2, 3"));
            Console.WriteLine(sc.Add("11,23,45"));
            Console.WriteLine(sc.Add("1,2,3,4,5,6,7,8,9,10"));
            Console.WriteLine(sc.Add("//;\n1;2"));
            Console.WriteLine(sc.Add("1001, 2"));
            Console.WriteLine(sc.Add("//[::]\n2::3"));
            Console.WriteLine(sc.Add("//[*][%]\n1*2%3"));
            Console.WriteLine(sc.Add("9000,5001,4409"));

            try
            {
                sc.Add("//[##]\n1##2##-3##4##-5##6");
            }
            catch (NegativeNumbersException ex)
            {
                Console.WriteLine(ex.Message);
            }

            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();

            myLinkedList.PrintList();

            try
            {
                myLinkedList.Delete(10);
                myLinkedList.PrintList();
            }
            catch (DeleteLinkedListNodeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            myLinkedList.Insert(4, 4);
            myLinkedList.Insert(5, 5);
            myLinkedList.Insert(3, 3);
            myLinkedList.Insert(1, 1);
            myLinkedList.Insert(3, 3);
            myLinkedList.Insert(0, 0);
            myLinkedList.Insert(6, 6);

            myLinkedList.PrintList();

            try
            {
                myLinkedList.Delete(5);
                myLinkedList.PrintList();
            }
            catch (DeleteLinkedListNodeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                myLinkedList.Delete(0);
                myLinkedList.PrintList();
            }
            catch (DeleteLinkedListNodeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                myLinkedList.Delete(10);
                myLinkedList.PrintList();
            }
            catch (DeleteLinkedListNodeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                myLinkedList.Delete(5);
                myLinkedList.PrintList();
            }
            catch (DeleteLinkedListNodeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
