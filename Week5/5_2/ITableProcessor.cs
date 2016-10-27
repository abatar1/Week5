namespace Week5
{
    public interface ITableProcessor
    {
        void Put(int row, int column, int value);
        void InsertRow(int rowIndex);
        void InsertColumn(int columnIndex);
        void Get(int row, int column);
    }
}
