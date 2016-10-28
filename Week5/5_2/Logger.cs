using System;

namespace Week5
{
    public class Logger
    {
        private void MethodInvoked(object sender, LoggerEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        public void AddLogger<T>(DataTable<T> dataTable)
        {
            dataTable.LoggerEvent += MethodInvoked;
        }
    }
}
