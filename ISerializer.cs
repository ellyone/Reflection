using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    interface ISerializer
    {
        string CsvSerialize (object obj);
        T CsvDeserialize<T>(string input) where T : class, new();
    }
}
