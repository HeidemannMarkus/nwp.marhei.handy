using System;

namespace ConsoleApplication1.Input
{
   public static class Helper
   {
      public static char CustomReadKey()
      {
         var inputKey = Console.Read();
         var returnChar = 'q';
         
         return returnChar;
      }
   }
}
