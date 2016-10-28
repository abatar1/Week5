namespace Week5
{
    public interface IDataTable<TType>
    {
        TType Get(int row, int column);
        void InsertColumn(int columnIndex);
        void InsertRow(int rowIndex);
        void Put(int row, int column, TType value);
    }
}
