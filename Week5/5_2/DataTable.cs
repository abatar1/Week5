using System;
using System.Collections.Generic;
using System.Linq;

namespace Week5
{
    public class DataTable<TType>
    {
        private List<List<TType>> table;

        private int rowCount;
        private int columnCount;

        public event EventHandler<LoggerEventArgs> LoggerEvent;

        public DataTable()
        {
            table = new List<List<TType>>();
            rowCount = 0;
            columnCount = 0;
        }

        private bool ValueInRange(int row, int column)
        {
            OnLogger(new LoggerEventArgs("ValueInRange"));

            return (row < rowCount && column < columnCount) ? true : false;
        }

        public TType Get(int row, int column)
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

            if (rowCount == 0)
            {
                table.Add(new List<TType>());
                rowCount++;
            }
            for (int i = 0; i < rowCount; i++)
            {
                if (columnIndex > columnCount)
                    table[i].AddRange(Enumerable.Repeat(default(TType), columnIndex - columnCount));
                else
                    table[i].Insert(columnIndex, default(TType));
            }
            columnCount++;
        }

        public void InsertRow(int rowIndex)
        {
            OnLogger(new LoggerEventArgs("InsertRow"));

            if (rowIndex > rowCount)
                table.AddRange(Enumerable.Repeat(new List<TType>(), rowIndex - rowCount));    
            else                   
                table.Insert(rowIndex, new List<TType>());
            rowCount++;
        }

        public void Put(int row, int column, TType value)
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
