using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoForIt
{
    public class Threads
    {
        private static int counter = 0;
        // Task1 acquires the lock on typeof(int) and waits to acquire typeof(long).
        // Task2 acquires the lock on typeof(long) and waits to acquire typeof(int).
        // Both tasks hold a lock and are waiting for the other lock to be released,
        // creating a deadlock.
        // Always acquire locks in a consistent order across all threads. If multiple locks are needed,
        // ensure that they are always acquired in the same sequence.
        // Avoid nested locks
        // Locks: Use locks to synchronize access to shared resources, ensuring thread safety and preventing race conditions.
        public void Test()
        {
            var t1 = Task.Run(Task1);
            var t2 = Task.Run(Task2);
            Task.WaitAll(t1, t2);
            Console.WriteLine("All tasks finished!");
        }

        private static void Task1()
        {
            Console.WriteLine("Task 1 started");
            lock (typeof(object))
            {
                Thread.Sleep(1000);
                lock (typeof(object))
                {
                    Console.WriteLine("Task 1 finished");
                }
            }
        }

        private static void Task2()
        {
            Console.WriteLine("Task 2 started");
            lock (typeof(object))
            {
                Thread.Sleep(1000);
                lock (typeof(object))
                {
                    Console.WriteLine("Task 2 finished");
                }
            }
        }
        public void Test2()
        {
            const int numberOfBalanceIncreases = 100;
            const int numberOfRuns = 1000;
            const int expectedBalanceSum = numberOfRuns * numberOfBalanceIncreases;
            var actualBalanceSum = 0;

            for (int i = 0; i < numberOfRuns; i++)
            {
                actualBalanceSum += IncreaseBalance(numberOfBalanceIncreases);
            }

            Console.WriteLine(actualBalanceSum == expectedBalanceSum ? $"Correct! Balance sum is {actualBalanceSum}" : $"Wrong! Balance sum is {actualBalanceSum} but expected was {expectedBalanceSum}");
        }


        // Here, balance++ is not an atomic operation.
        // It involves reading the current value of balance, incrementing it, and writing it back.
        // When multiple tasks perform this operation simultaneously,
        // some increments can be lost because tasks might read the same initial value
        // before any writes have been completed by other tasks.
        private int IncreaseBalance(int numberOfBalanceIncreases)
        {
            var balance = 0;
            var tasks = new List<Task>();
            for (int i = 0; i < numberOfBalanceIncreases; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    lock (typeof(object))
                    {
                        balance++;
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            return balance;
        }

        public void Test3()
        {
            Thread t1 = new Thread(IncrementCounter);
            Thread t2 = new Thread(IncrementCounter);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"Final counter value: {counter}");
        }

        static void IncrementCounter()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (typeof(object))
                {
                    counter++;
                }
            }
        }
    }
}
