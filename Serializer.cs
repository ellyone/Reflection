using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Serializer : ISerializer
    {
        private const char Separator = ',';
        private const char NewLineSeparatorChar = '\n';
        private static readonly BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        public string CsvSerialize(object obj)
        {
            StringBuilder stringBuilder = new StringBuilder();

            FieldInfo[] fieldInfo = obj.GetType().GetFields(bindingAttr: bindingFlags);
            stringBuilder.AppendLine(String.Join(Separator, fieldInfo.Select(x=>x.Name)));
            var values = new List<string>();
            foreach (var field in fieldInfo)
            {
                values.Add(field.GetValue(obj).ToString());
            }
            stringBuilder.AppendLine(String.Join(Separator, values));

            return stringBuilder.ToString();
        }

        public T CsvDeserialize<T>(string input) where T : class, new() 
        {
            T obj = new T();

            var type = obj.GetType();//.GetFields(bindingAttr: bindingFlags);

            var lines = input.Split('\n', (char)StringSplitOptions.RemoveEmptyEntries);
            var fields = lines[0].Split(Separator);
            var values = lines[1].Split(Separator);

            for(int i = 0; i < fields.Length; i++)
            {
                var field = type.GetField(fields[i].Trim(), bindingFlags);

                if (field != null)
                {
                    var value = Convert.ChangeType(values[i], field.FieldType);
                    field.SetValue(obj, value);
                }
            }



            return obj;
        }
    }
}
