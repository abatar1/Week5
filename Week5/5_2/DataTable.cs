using System;
using System.Collections.Generic;
using System.Linq;

namespace Week5
{
    public class DataTable<TType> : IDataTable<TType>
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
            return (row < rowCount && column < columnCount) ? true : false;
        }

        private void InsertWithExtension<TContainer, TFiller>(TContainer container, TFiller filler, int insertIndex)
            where TContainer : List<TFiller>
        {
            var containerSize = container.Count();
            if (insertIndex > containerSize)
                container.AddRange(Enumerable.Repeat(filler, insertIndex - containerSize));
            else
                container.Insert(containerSize, filler);
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
                InsertWithExtension(table[i], default(TType), columnIndex);
            }
            columnCount++;
        }

        public void InsertRow(int rowIndex)
        {
            OnLogger(new LoggerEventArgs("InsertRow"));

            InsertWithExtension(table, new List<TType>(), rowIndex);
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
