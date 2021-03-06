﻿using System;
using nwp.marhei.mobilephoneLibary;
using ParserLibrary;

namespace nwp.marhei.mobilephone
{
   class mobilephoneTest
   {
      static void Main(string[] args)
      {
         var loadpath =
              @"D:\MyUserData\Documents\Ausbildung\Vertiefung - Programmiertechnik\nwp.marhei.handy\nwp.marhei.handy\nwp.marhei.mobilephoneLibary\Serialize\handyList.dat";

         var phoneList = new BinaryParser().FromFile<MobilePhoneList>(loadpath);
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
//            Console.WriteLine((phoneList.GetThreeCheapestMobilePhones()));
         }
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
         }
         var filepath =
              @"D:\MyUserData\Documents\Ausbildung\Vertiefung - Programmiertechnik\nwp.marhei.handy\nwp.marhei.handy\nwp.marhei.mobilephoneLibary\Serialize\handyList.json";


         new JsonParser().ToFile(filepath, phoneList);

         Console.WriteLine(new JsonParser().FromFile<MobilePhoneList>(filepath));
         Console.ReadKey();
      }
   }
}