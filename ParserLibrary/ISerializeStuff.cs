namespace ParserLibrary
{
   public interface ISerializeStuff
   {
     void ToFile<T>(string filepath, T toSerialize );
      T FromFile<T>(string filepath);
   }
}
