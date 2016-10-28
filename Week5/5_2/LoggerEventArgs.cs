using System;

namespace Week5
{
    public class LoggerEventArgs
    {
        private string methodName;
        private DateTime time;

        public LoggerEventArgs(string methodName)
        {
            this.methodName = methodName;
            this.time = DateTime.Now;
        }

        public override string ToString()
        {
            return methodName.ToString() + " at " + time.ToString();
        }
    }
}
