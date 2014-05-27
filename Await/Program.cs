using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Await
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is the method we want to run asynchronously...
            CallLongRunningMethod();

            // Continue processing while we wait
            Console.WriteLine("Working...");
            Console.Read();
        }

        // Our async method is called. This is the tip-off that we are going to allow processing to continue.
        private static async void CallLongRunningMethod()
        {
            // We then call a method that is going to do our threaded work.
            string result = await LongRunningMethodAsync("World");
            Console.WriteLine(result);
        }

        private static Task<string> LongRunningMethodAsync(string message)
        {
            return Task.Run<string>(() => LongRunningMethod(message));
        }

        private static string LongRunningMethod(string message)
        {
            Thread.Sleep(2000);
            return "Hello " + message;
        }
    }
}
