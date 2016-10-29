using System;

namespace Week5
{
    public class LoggerEventArgs
    {
        private string methodName;
        private DateTime time;
        private string subject;

        public LoggerEventArgs(string methodName, string act)
        {
            this.methodName = methodName;            
            this.time = DateTime.Now;
            this.subject = act;
        }

        public override string ToString()
        {
            return "User did " + methodName.ToString() + 
                " with " + subject.ToString() + 
                " at " + time.ToString();
        }
    }
}
