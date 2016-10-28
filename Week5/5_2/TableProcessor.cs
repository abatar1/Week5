using System;
using System.Collections.Generic;

namespace Week5
{
    public class DataTable<T>
    {
        private List<List<T>> table;       

        private int rowCount = 0;
        private int columnCount = 0;

        public event EventHandler<LoggerEventArgs> LoggerEvent;

        private bool ValueInRange(int row, int column)
        {
            OnLogger(new LoggerEventArgs("ValueInRange"));

            return (row < rowCount && column < columnCount) ? true : false;
        }

        public T Get(int row, int column)
        {
            OnLogger(new LoggerEventArgs("Get"));

            if (ValueInRange(row, column))
                return table[row][column];
            else
                throw new IndexOutOfRangeException();
        }

        public void InsertColumn(int columnIndex)
        {
            OnLogger(new LoggerEventArgs("InsertColumn"));

            columnCount++;
            if (rowCount == 0) rowCount++;
            foreach (var cell in table)
            {
                cell.Insert(columnIndex, default(T));
            }
        }

        public void InsertRow(int rowIndex)
        {
            OnLogger(new LoggerEventArgs("InsertRow"));

            rowCount++;
            table.Insert(rowIndex, default(List<T>));
        }

        public void Put(int row, int column, T value)
        {
            OnLogger(new LoggerEventArgs("Put"));

            if (ValueInRange(row, column))
                table[row][column] = value;
            else
                throw new IndexOutOfRangeException();
        }

        protected virtual void OnLogger(LoggerEventArgs e)
        {
            LoggerEvent?.Invoke(this, e);
        }
    }
}
