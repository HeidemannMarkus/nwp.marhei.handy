﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using FileHelpers;

namespace nwp.marhei.mobilephoneLibary
{
   [Serializable]
   [DataContract]
   [DelimitedRecord(",")]
   public class Mobilephone : DomainObject, IMobilephone
   {
      [DataMember]
      public string Producer { get; set; }
      [DataMember]
      public string Model { get; set; }
      [DataMember]
      public string SerialNumber { get; set; }
      [DataMember]
      public double Price { get; set; }

      public Mobilephone(string producer, string model, string serialNumber, double price)
      {
         Producer = producer;
         Model = model;
         SerialNumber = serialNumber;
         Price = price;
      }

      public Mobilephone()
      {
         
      }

      public bool CustomEqual(Mobilephone phone)
      {
         var ePrice = phone.Price == 0 || phone.Price.Equals(Price);
         var eProducer = phone.Producer?.Equals(Producer) ?? true;
         var eSerialNumber = phone.SerialNumber?.Equals(SerialNumber) ?? true;
         var eModel = phone.Model?.Equals(Model) ?? true;

         return ePrice && eProducer && eSerialNumber && eModel;
      }

      public int GetProducerYear()
      {
         return SerialNumber.ElementAt(2);
      }

      public override string ToString()
      {
         return
            "Id:\t" + Id +
            "\nHersteller:\t" + Producer +
            "\nModel:\t" + Model +
            "\nSerienNummer:\t" + SerialNumber +
            "\nPreis:\t" + Price.ToString(CultureInfo.InvariantCulture)
            ;
      }
   }
}