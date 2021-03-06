﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace nwp.marhei.mobilephoneLibary.Exceptions
{
   [Serializable]
   public class MobilePhoneListIsEmptyException : Exception
   {
      //
      // For guidelines regarding the creation of new exception types, see
      //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
      // and
      //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
      //

      public MobilePhoneListIsEmptyException(): this("MobilephoneList is empty") 
      {
      }

      public MobilePhoneListIsEmptyException(string message) : base(message)
      {
      }

      public MobilePhoneListIsEmptyException(string message, Exception inner) : base(message, inner)
      {
      }

      protected MobilePhoneListIsEmptyException(
         SerializationInfo info,
         StreamingContext context) : base(info, context)
      {
      }
   }
}
