using System;

namespace nwp.marhei.mobilephoneLibary
{
   public interface IMobilephone
   {
      string Model { get; set; }
      double Price { get; set; }
      string Producer { get; set; }
      string SerialNumber { get; set; }

      int GetProducerYear();
      string ToString();
   }

   [Serializable]
   public abstract class DomainObject
   {
      protected Guid Id { get; set; }

      protected DomainObject()
      {
         Id = Guid.NewGuid();
      }
   }
}