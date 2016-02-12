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
         var switches = new List<Switch>
         {
            new Switch(new Lamp("First lamp switched off", "First lamp switched on")),
            new Switch(new Washer("First washer stopped", "First washer started"))
         };

         Console.WriteLine(" Eingabe von 2 Zeichen erwartet (q zum quit): \n\tIndex\n\tAction (e = on & a = off");

         string theKey = "q";
         do
         {
            theKey = Console.ReadLine();
            if (theKey.ElementAt(0) == 'q')
            {
               break;
            }
            switch (theKey.ElementAt(1))
            {
               case 'e':
                  switches[Int32.Parse(theKey.ElementAt(0).ToString())].SwitchOn();
                  break;
               case 'a':
                  switches[Int32.Parse(theKey.ElementAt(0).ToString())].SwitchOff();
                  break;
               default:
                  break;
            }
         } while (theKey != "q");
        
      }
   }
}
