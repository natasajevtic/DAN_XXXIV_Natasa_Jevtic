using System;
using System.Threading;

namespace Zadatak_1
{
    class Program
    {
        /// <summary>
        /// This method creates threads whose number depends on user input, starts that threads and every thread performs instance of ATM class method for which is created.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("How many customers would withdraw money from first ATM?");
            string firstInput = Console.ReadLine();
            bool conversion1 = Int32.TryParse(firstInput, out int firstNumber);
            while (!conversion1 || firstNumber < 0)
            {
                Console.WriteLine("Invalid input. Try again:");
                firstInput = Console.ReadLine();
                conversion1 = Int32.TryParse(firstInput, out firstNumber);
            }
            Console.WriteLine("How many customers would withdraw money from second ATM?");
            string secondInput = Console.ReadLine();
            bool conversion2 = Int32.TryParse(secondInput, out int secondNumber);
            while (!conversion2 || secondNumber < 0)
            {
                Console.WriteLine("Invalid input. Try again:");
                secondInput = Console.ReadLine();
                conversion2 = Int32.TryParse(secondInput, out secondNumber);
            }
            int numberOfCustomers = firstNumber + secondNumber;
            //creating array of threads, which length is equal to number of customers
            Thread[] threads = new Thread[numberOfCustomers];
            //creating two object of ATM class
            ATM firstATM = new ATM(1);
            ATM secondATM = new ATM(2);
            //filling array with threads, first with threads which performs withdraw money for customers on first ATM, and then with threads which performs withdraw on second ATM
            for (int i = 0; i < numberOfCustomers; i++)
            {
                if (i < firstNumber)
                {
                    Thread t1 = new Thread(firstATM.Withdraw);
                    threads[i] = t1;
                }
                else
                {
                    Thread t2 = new Thread(secondATM.Withdraw);
                    threads[i] = t2;
                }

            }
            //starting every thread in array of threads
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }
            Console.ReadLine();
        }
    }
}

