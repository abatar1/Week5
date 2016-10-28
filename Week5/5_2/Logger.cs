using System;

namespace Week5
{
    public class Logger
    {
        public static void MethodInvoked(object sender, LoggerEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
