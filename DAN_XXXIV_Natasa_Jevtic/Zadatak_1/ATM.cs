using System;

namespace Zadatak_1
{
    /// <summary>
    /// This class is responsible for creating ATM objects and withdraw money from bank.
    /// </summary>
     class ATM
    {
        //amount of money available in the bank
        public static int money = 10000;
        //number of ATM
        public int id;
        //ordinal number of the client in the bank
        public static int customerNumber = 0;
        public static object locker = new object();
        static Random random = new Random();
        /// <summary>
        /// Constructor with one parameter.
        /// </summary>
        /// <param name="number">Number of ATM.</param>
        public ATM(int number)
        {
            id = number;
        }
        /// <summary>
        /// This method reduces money in the bank for some random amount, if the bank has enough money, and displays to console feedback about success of the action.
        /// </summary>
        public void Withdraw()
        {    
            //locking block of code, that only one customers can withdraw money from bank in the same time
            //only one thread can perform statements in lock block in the same time
            lock (locker)
            {               
                int amount = random.Next(100, 10000);
                Console.WriteLine("Customer {0} is trying to withdraw amount of {1} RSD from ATM {2}.", ++customerNumber, amount, id);
                if (money >= amount)
                {
                    money -= amount;
                    Console.WriteLine("Customer {0} withdraw amount of {1} RSD from ATM {2}.", customerNumber, amount, id);
                    Console.WriteLine("Money in bank after withdraw: {0} RSD", money);
                }
                else
                {
                    Console.WriteLine("Customer {0} cannot withdraw amount of {1} RSD from ATM {2}.", customerNumber, amount, id);
                }
            }           
        }        
    }
}
