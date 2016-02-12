using System;

namespace ConsoleApplication1.Output
{
   public class Switchable: ISwitchable
   {
      private bool _status;
      private readonly string _onMessage;
      private readonly string _offMessage;

      public Switchable(string offMessage, string onMessage)
      {
         _offMessage = offMessage;
         _onMessage = onMessage;
      }

      public bool On()
      {
         if (_status)
         {
            return false;
         }
         _status = true;
         Console.WriteLine(_onMessage);
         return true;
      }

      public bool Off()
      {
         if (!_status)
         {
            return false;
         }
         _status = false;
         Console.WriteLine(_offMessage);
         return true;
      }
   }
}
