using System.IO;
using System.Runtime.Serialization.Json;

namespace ParserLibrary
{
   public class JsonParser : ISerializeStuff
   {
      public void ToFile<T>(string filepath, T toSerialize)
      {
         FileStream stream = new FileStream(filepath, FileMode.Create);
         DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
         ser.WriteObject(stream, toSerialize);
         stream.Close();
      }

      public T FromFile<T>(string filepath)
      {
         FileStream stream = new FileStream(filepath, FileMode.Open);
         DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
         T deserialized = (T) ser.ReadObject(stream);
         stream.Close();
         return deserialized;
      }
   }
}
