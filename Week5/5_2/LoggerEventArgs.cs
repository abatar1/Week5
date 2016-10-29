using System;

namespace Week5
{
    public class LoggerEventArgs
    {
        private string methodName;
        private DateTime time;
        private Position pos;

        public LoggerEventArgs(string methodName, Position pos)
        {
            this.methodName = methodName;            
            this.time = DateTime.Now;
            this.pos = new Position(pos);
        }

        public override string ToString()
        {
            return "User did " + methodName.ToString() + 
                " with " + pos.ToString() + 
                " at " + time.ToString();
        }
    }
}
