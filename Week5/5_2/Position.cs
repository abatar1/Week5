namespace Week5
{
    public class Position
    {
        private int row;
        private int column;

        public Position(int row = default(int), int column = default(int))
        {
            this.row = row;
            this.column = column;
        }

        public Position(Position pos)
        {
            row = pos.row;
            column = pos.column;
        }

        public override string ToString()
        {
            string result = "";
            if (row != default(int)) result += "row = " + row.ToString();
            if (column != default(int)) result += "column = " + column.ToString();
            return result;
        }
    }
}
