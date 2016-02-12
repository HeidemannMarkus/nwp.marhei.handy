using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Input;
using ConsoleApplication1.Logic;
using ConsoleApplication1.Output;

namespace ConsoleApplication1
{
   class Program
   {
      static void Main(string[] args)
      {
         var myLamp = new Lamp("Lamp switched on", "Lamp switched off");
         var mySwitch = new Switch(myLamp);

         var mySwitch2 = new Switch(new Washer("Washer stopped", "Washer started"));

         string theKey = "q";
         do
         {
            theKey = Console.ReadLine();
            switch (theKey.ElementAt(0))
            {
               case 'e':
                  mySwitch.SwitchOn();
                  break;
               case 'a':
                  mySwitch.SwitchOff();
                  break;
               default:
                  break;
            }
         } while (theKey != "q");
        
      }
   }
}
