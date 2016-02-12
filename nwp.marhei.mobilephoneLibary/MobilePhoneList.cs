using System;
using System.Collections.Generic;
using System.Linq;
using nwp.marhei.mobilephoneLibary.Exceptions;

namespace nwp.marhei.mobilephoneLibary
{
   [Serializable]
   public class MobilePhoneList : List<Mobilephone>, IMobilePhoneList
   {
      public MobilePhoneList()
      {
      }

      public MobilePhoneList(IEnumerable<Mobilephone> phones)
      {
         this.AddRange(phones);
      }

      public override string ToString()
      {
         var returnvalue = "";
         base.ForEach(c => returnvalue += "\n" + c.ToString());
         return returnvalue;
      }

      public Mobilephone GetHandy(string serialNumber)
      {
         return this.Single(current => Equals(current.SerialNumber, serialNumber));
      }

      public void AddHandy(Mobilephone newHandy)
      {
         this.Add(newHandy);
      }

      public MobilePhoneList Search(string producer)
      {
         var enumerable = this.Where(current => Equals(current.Producer, producer)).ToList();
         if (!enumerable.Any())
         {
            throw new MobilePhoneListIsEmptyException();
         }
         return new MobilePhoneList(enumerable.Select(current => new Mobilephone(current.Producer
            , current.Model, current.SerialNumber, current.Price)));
      }

      public MobilePhoneList Search(Mobilephone searched)
      {
         var enumerable = this.Where(current => current.CustomEqual(searched)).ToList();
         if (!enumerable.Any())
         {
            throw new MobilePhoneListIsEmptyException();
         }
         return new MobilePhoneList(enumerable);
      }

      public MobilePhoneList GetCheapestMobilePhones()
      {
         var lowestPrice = this.Min(current => current.Price);
         return this.Where(current => Equals(current.Price, lowestPrice)) as MobilePhoneList;
      }

      public MobilePhoneList GetThreeCheapestMobilePhones()
      {
         return new MobilePhoneList(this.OrderBy(c => c.Price).Take(3));
      }

      /*public MobilePhoneList GetAllModelsToTheCheapestThreePrices()
      {
         
      }*/
   }
}