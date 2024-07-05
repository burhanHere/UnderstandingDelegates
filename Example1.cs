using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnderstandingDelegates
{
    internal class Example1
    {
        delegate void NotifyCallback(string str);

        static void Notify(string name, CancellationToken token)
        {
            for (int i = 0; i < 10; i++)
            {
                // Check if cancellation is requested
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Notification thread cancelled.");
                    return;
                }

                Console.WriteLine($"Notification received for: {name}");
                Thread.Sleep(1000);
            }
        }

        public static void test()
        {
            // Create cancellation token source
            CancellationTokenSource cts = new();
            CancellationToken token = cts.Token;

            // Create an instance of the delegate
            NotifyCallback del1 = new(name => Notify(name, token));

            // Create and start the notification thread
            Thread trd = new(() => del1("Burhan"));
            trd.Start();

            // Create and start the cancellation thread
            Thread trd2 = new(() =>
            {
                Console.WriteLine("Press ENTER to terminate the printing.");
                Console.ReadLine();
                cts.Cancel(); // Cancel the token source
            });
            trd2.Start();

            // Join threads
            trd.Join();
            trd2.Join();
        }
    }
}
