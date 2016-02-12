using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Output;

namespace ConsoleApplication1.Logic
{
   public class Switch : ISwitch
   {
      private ISwitchable _onOff;

      public Switch(ISwitchable onOff)
      {
         this._onOff = onOff;
      }

      public void SwitchOn()
      {
         if (!_onOff.On())
         {
            Console.WriteLine("Is on already");
         }
      }

      public void SwitchOff()
      {
         if (!_onOff.Off())
         {
            Console.WriteLine("Is off already");
         }
      }
   }
}
