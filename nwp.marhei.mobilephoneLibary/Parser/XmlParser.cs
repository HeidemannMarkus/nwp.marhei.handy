﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace nwp.marhei.mobilephoneLibary.Parser
{
   public class XmlParser: ISerializeStuff
   {
      public void ToFile<T>(string filepath, T toSerialize)
      {
         XmlSerializer serializer = new XmlSerializer(typeof(T));
         FileStream stream =
            new FileStream(
               filepath,
               FileMode.Create);
         serializer.Serialize(stream, toSerialize);
         stream.Close();
      }

      public T FromFile<T>(string filepath)
      {
         XmlSerializer serializer = new XmlSerializer(typeof(T));
         FileStream stream =
            new FileStream(
               filepath,
               FileMode.Open);
         var ret = serializer.Deserialize(stream);
         stream.Close();
         return (T)ret;
      }
   }
}