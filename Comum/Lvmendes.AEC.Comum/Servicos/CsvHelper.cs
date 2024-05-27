using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.AEC.Comum.Servicos
{
    public static class CsvHelper
    {

        public static string WriteCsv<T>(List<T> items, string delimiter = ";")
        {
            var type = typeof(T);
            var properties = type.GetProperties();

            var sb = new StringBuilder();

            // Write the header
            sb.AppendLine(string.Join(delimiter, properties.Select(p => p.Name)));

            // Write the rows
            foreach (var item in items)
            {
                var values = properties.Select(p => p.GetValue(item, null)?.ToString());
                sb.AppendLine(string.Join(delimiter, values));
            }

            return sb.ToString();
        }
    }
}
