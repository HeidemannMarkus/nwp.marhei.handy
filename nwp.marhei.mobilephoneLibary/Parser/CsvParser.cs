using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace nwp.marhei.mobilephoneLibary.Parser
{
   class CsvParser: ISerializeStuff
   {
      public void ToFile<T>(string filepath, T toSerialize)
      {
         throw new NotImplementedException();
      }

      public T FromFile<T>(string filepath)
      {
         throw new NotImplementedException();
      }
      public static IEnumerable<string> ToCsv<T>(string separator, IEnumerable<T> objectlist)
      {
         FieldInfo[] fields = typeof(T).GetFields();
         PropertyInfo[] properties = typeof(T).GetProperties();
         yield return String.Join(separator, fields.Select(f => f.Name).Concat(properties.Select(p => p.Name)).ToArray());
         foreach (var o in objectlist)
         {
            yield return string.Join(separator, fields.Select(f => (f.GetValue(o) ?? "").ToString())
                .Concat(properties.Select(p => (p.GetValue(o, null) ?? "").ToString())).ToArray());
         }
      }
   }
}
