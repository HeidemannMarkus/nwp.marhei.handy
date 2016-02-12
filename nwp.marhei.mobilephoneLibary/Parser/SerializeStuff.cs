using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace nwp.marhei.mobilephoneLibary.Parser
{
   public static class SerializeStuff 
   {
      public static void AsXml<T>(string filepath, T toSerialize)
      {
         XmlSerializer serializer = new XmlSerializer(typeof(T));
         FileStream stream =
            new FileStream(
               filepath,
               FileMode.Create);
         serializer.Serialize(stream, toSerialize);
         stream.Close();
      }
      public static T FromXml<T>(string filepath, T instanceOfType)
      {
         XmlSerializer serializer = new XmlSerializer(typeof(T));
         FileStream stream =
            new FileStream(
               filepath,
               FileMode.Open);
         var ret = serializer.Deserialize(stream);
         stream.Close();
         return (T) ret;
      }
      public static void AsBinary(string filepath, object toSerialize)
      {
         FileStream stream =
            new FileStream(
               filepath,
               FileMode.Create);
         BinaryFormatter formatter = new BinaryFormatter();
         formatter.Serialize(stream, toSerialize);
         stream.Close();
      }

      public static MobilePhoneList FromBinary(string filepath)
      {
         var stream = new FileStream(
            filepath,
            FileMode.Open);
         BinaryFormatter formatter = new BinaryFormatter();
         var deserialized = formatter.Deserialize(stream);
         stream.Close();

         return deserialized as MobilePhoneList;
      }
   }
}
