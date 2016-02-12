using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using nwp.marhei.mobilephoneLibary;
using nwp.marhei.mobilephoneLibary.Parser;

namespace nwp.marhei.mobilephone
{
   class mobilephoneTest
   {
      static void Main(string[] args)
      {
         var loadpath =
              @"D:\MyUserData\Documents\Ausbildung\Vertiefung - Programmiertechnik\nwp.marhei.handy\nwp.marhei.handy\nwp.marhei.mobilephoneLibary\Serialize\handyList.xml";

         var phoneList = SerializeStuff.FromXml(loadpath, new MobilePhoneList());
         /*var phoneList = new MobilePhoneList
         {
            new Mobilephone
            {
               Model = "Iphone",
               SerialNumber = "83938S3TY5K",
               Price = 1000,
               Producer = "Apple"
            },
            new Mobilephone
            {
               Model = "Lumia 924",
               SerialNumber = "83338S3TY5K",
               Price = 400,
               Producer = "Nokia"
            },
            new Mobilephone
            {
               Model = "Lumia 925",
               SerialNumber = "83338S3TY5K",
               Price = 500,
               Producer = "Nokia"
            },
            new Mobilephone
            {
               Model = "Lumia 920",
               SerialNumber = "83338S3TY5K",
               Price = 460,
               Producer = "Nokia"
            },
            new Mobilephone
            {
               Model = "Lumia 922",
               SerialNumber = "83338S3TY5K",
               Price = 460,
               Producer = "Nokia"
            }
         };*/
         try
         {
            var temp = new Mobilephone {Producer = "Apple"};
            //Console.WriteLine(phoneList.Search(temp));
            Console.WriteLine((phoneList.GetThreeCheapestMobilePhones()));
         }
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
         }
         var filepath =
              @"D:\MyUserData\Documents\Ausbildung\Vertiefung - Programmiertechnik\nwp.marhei.handy\nwp.marhei.handy\nwp.marhei.mobilephoneLibary\Serialize\handyList.xml";


//         SerializeStuff.AsXml(filepath, phoneList);

         //Console.WriteLine(phoneList.ToString());
         Console.ReadKey();
      }
   }
}