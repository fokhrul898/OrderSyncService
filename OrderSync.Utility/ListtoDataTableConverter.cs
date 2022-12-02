using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace OrderSync.Utility
{
    public class ListtoDataTableConverter
    {
        private static readonly object padlock = new object();
        private static ListtoDataTableConverter Instance = null;
        public static ListtoDataTableConverter GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (Instance == null)
                    {
                        Instance = new ListtoDataTableConverter();
                    }
                    return Instance;
                }
            }
        }
        private ListtoDataTableConverter()
        {

        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}
