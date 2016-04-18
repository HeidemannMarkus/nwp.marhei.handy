using System.Collections;
using System.Collections.Generic;
using FileHelpers;

namespace nwp.marhei.mobilephoneLibary.Parser
{
   public class CsvParser 
   {
      public void ToFile<T>(string filepath, IEnumerable<T> toSerialize) where T : class
      {
         var engine = new FileHelperEngine<T>();
         engine.WriteFile(filepath, toSerialize);

      }

      public List<T> FromFile<T>(string filepath) where T : class 
      {
         var engine = new FileHelperEngine<T>();
         return new List<T>(engine.ReadFile(filepath));
      }
   }
}
