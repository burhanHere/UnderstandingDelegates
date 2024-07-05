using BookTestClient;
using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UnderstandingDelegates
{
    internal class Practice1
    {
        private delegate double CalculateArea(double side);
        private static double SideInput(int sideNumber)
        {
            double result;
            while (true)
            {
                Console.Write($"Enter value of side{(sideNumber != 0 ? sideNumber.ToString() : "")}: ");
                if (double.TryParse(Console.ReadLine() ?? "0", result: out result))
                {
                    break;
                }
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Try Again");
            }
            return result;
        }
        private static double QuadrilatralArea(double side) => side * side;
        private static double CircleArea(double radious) => Math.PI * Math.Pow(radious, 2);
        private static void Question1()
        {
            //1.Multicast Delegate Behavior:
            //Write a program that defines a delegate for calculating the area of different shapes(e.g., square, circle).Create methods for calculating the area of each shape and assign them to the delegate.Invoke the delegate and observe the output(consider using a switch statement based on the shape type).
            bool loopActive = true;
            while (loopActive)
            {

                Console.WriteLine("Select the shape of which you want to find tha area.");
                Console.WriteLine("Enter S for Square.");
                Console.WriteLine("Enter C for Circle.");
                Console.WriteLine("Enter X to Exit.");

                string input = Console.ReadLine() ?? "";

                CalculateArea AreaCalculater = new(QuadrilatralArea);
                AreaCalculater += CircleArea;

                switch (input)
                {
                    case "S":
                        double SquareSide1 = SideInput(sideNumber: 0);
                        AreaCalculater += QuadrilatralArea;
                        Console.WriteLine($"Area of Square: {AreaCalculater(SquareSide1)}");
                        break;
                    case "C":
                        double CircleRadious = SideInput(sideNumber: 0);
                        AreaCalculater += CircleArea;
                        Console.WriteLine($"Area of Rectangle: {AreaCalculater(CircleRadious)}");
                        break;
                    case "X":
                        Console.Clear();
                        loopActive = false;
                        Console.Write("Good Bye...");
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }
            }
        }
        private static void Question2()
        {
            //2.Singlecast vs.Multicast:
            //Modify the previous program to demonstrate the difference between singlecast and multicast delegates.Initially, assign only one method to the delegate (singlecast).Then, add another method using the += operator (multicast).Observe how the invocation behavior changes.
        }
        private delegate bool Compair(int number1, int number2);
        private static void MySort(Compair myCompair, List<int> inputList)
        {
            int temp;
            for (int i = 0; i < inputList.Count; i++)
            {
                for (int j = i + 1; j < inputList.Count; j++)
                {
                    if (myCompair(inputList[i], inputList[j]))
                    {
                        temp = inputList[i];
                        inputList[i] = inputList[j];
                        inputList[j] = temp;
                    }
                }
            }
        }
        private static void Question3()
        {
            //3.Sorting with Delegates:
            //Create a delegate for comparing two integers.Implement methods for ascending and descending order comparison.Use these methods with an appropriate sorting algorithm(e.g., bubble sort) to sort an array of integers in both ascending and descending order
            List<int> myList = [52, 5, 54, 5, 6, 2, 45, 854, 58, 3, 13, 15, 545, 1, 1, 6515, 1, 65, 651, 5];

            Console.Write("Before Sorting: ");
            foreach (var i in myList)
            {
                Console.Write(i.ToString() + ' ');
            }
            MySort((number1, number2) => number1 > number2, myList);// sorting accending
            Console.WriteLine("\nAfter Sorting accending: ");
            foreach (var i in myList)
            {
                Console.Write(i.ToString() + ' ');
            }
            MySort((number1, number2) => number1 < number2, myList);// sorting accending
            Console.WriteLine("\nAfter Sorting accending: ");
            foreach (var i in myList)
            {
                Console.Write(i.ToString() + ' ');
            }
        }
        private static void Question4()
        {
            //4.Event Simulation with Delegates:
            //Simulate a simple event (e.g., button click) using a delegate. Define methods for different actions triggered by the event (e.g., displaying a message, performing a calculation). Subscribe these methods to the delegate and then invoke the delegate to simulate the event and observe the subscribed actions being executed.
        }
        private static void Question5()
        {
            //5.Lambda Expressions with Delegates:
            //Rewrite any of the previous examples using lambda expressions to define the methods assigned to the delegates. Explore the benefits of using lambda expressions for concise and anonymous methods.
        }
        private static void Question6()
        {
            //Bonus Challenge:
            //Create a delegate for performing string manipulations(e.g., uppercase, lowercase, reverse).Implement methods for these manipulations. Design a menu - driven program that allows the user to choose a string manipulation and then enter a string.Use the delegate and chosen method to perform the manipulation and display the result.
        }
        public static void TestMain()
        {
            //Question1();
            //Question2();
            Question3();
            //Question4();
            //Question5();
            //Question6();
        }
    }
}
