using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ParserLibrary
{
   public class BinaryParser : ISerializeStuff
   {
      public void ToFile<T>(string filepath, T toSerialize)
      {
         FileStream stream =
            new FileStream(
               filepath,
               FileMode.Create);
         BinaryFormatter formatter = new BinaryFormatter();
         formatter.Serialize(stream, toSerialize);
         stream.Close();
      }

      public T FromFile<T>(string filepath)
      {
         var stream = new FileStream(
            filepath,
            FileMode.Open);
         BinaryFormatter formatter = new BinaryFormatter();
         T deserialized = (T)Convert.ChangeType(formatter.Deserialize(stream), typeof(T));
         stream.Close();

         return deserialized;
      }
   }
}
