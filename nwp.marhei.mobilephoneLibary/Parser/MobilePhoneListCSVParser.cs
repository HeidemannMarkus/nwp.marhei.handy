using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace nwp.marhei.mobilephoneLibary.Parser
{

   public class MobilePhoneListCsvParser
   {
      private static IEnumerable<string> ToCsv<T>(string separator, IEnumerable<T> objectlist)
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

      public void ToFile(string filepath, MobilePhoneList list)
      {
         StreamWriter sw = new StreamWriter(filepath);
         var parsed = ToCsv(";", list);

         foreach (var mobilePhone in parsed)
         {
            sw.WriteLine(mobilePhone);
         }
         sw.Close();
      }
   }
}
