using System;

namespace Week5
{
    public class LoggerEventArgs
    {
        private string methodName;
        private DateTime time;
        private Position pos;

        public LoggerEventArgs(string methodName, int row = 0, int column = 0)
        {
            this.methodName = methodName;            
            this.time = DateTime.Now;
            this.pos = new Position(row, column);
        }

        public override string ToString()
        {
            return "User did " + methodName.ToString() + 
                " with " + pos.ToString() + 
                " at " + time.ToString();
        }
    }

    internal class Position
    {
        private int row;
        private int column;

        internal Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public override string ToString()
        {
            string result = "";
            if (row != 0) result += "row = " + row.ToString() + " ";
            if (column != 0) result += "column = " + column.ToString();
            return result;
        }
    }

}
