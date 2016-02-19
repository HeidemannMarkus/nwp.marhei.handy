using System;

namespace ConsoleApplication1.Output
{
   [Serializable]
   public class Lamp : ISwitchable
   {
      private bool _status;
      public string OnMessage { private get; set; }
      public string OffMessage { private get; set; }

      public bool On()
   {
      if (_status)
      {
         return false;
      }
      _status = true;
      Console.WriteLine(OnMessage);
      return true;
   }

   public bool Off()
   {
      if (!_status)
      {
         return false;
      }
      _status = false;
      Console.WriteLine(OffMessage);
      return true;
   }
}
}
