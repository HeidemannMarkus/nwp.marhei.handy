using System.Runtime.InteropServices.ComTypes;

namespace nwp.marhei.mobilephoneLibary.Parser
{
   public interface ISerializeStuff
   {
     void ToFile<T>(string filepath, T toSerialize );
      T FromFile<T>(string filepath);
   }
}
