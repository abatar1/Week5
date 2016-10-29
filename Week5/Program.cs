namespace Week5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataTable<int> table = new DataTable<int>();
            Logger logger = new Logger();
            logger.AddLogger(table);
            table.InsertColumn(1);
            table.InsertRow(2);            
        }
    }
}
