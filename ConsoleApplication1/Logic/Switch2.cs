using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Output;

namespace ConsoleApplication1.Logic
{
   [Serializable]
   public class Switch : ISwitch
   {
      public ISwitchable OnOff { get; set; }
      
      public void SwitchOn()
      {
         if (!OnOff.On())
         {
            Console.WriteLine("Is on already");
         }
      }

      public void SwitchOff()
      {
         if (!OnOff.Off())
         {
            Console.WriteLine("Is off already");
         }
      }
   }
}
