using System;
using System.Runtime.Serialization;

namespace GnomeVillage.Application.Common.Exceptions
{
   [Serializable]
   public class NotFoundException : ApplicationBaseException
   {
      private const int StatusValue = 404;

      public NotFoundException() : base(typeof(NotFoundException).Name, StatusValue)
      {
      }

      public NotFoundException(string message) : base(typeof(NotFoundException).Name, StatusValue, message)
      {
      }

      public NotFoundException(string message, Exception innerException) : base(typeof(NotFoundException).Name, StatusValue, message, innerException)
      {
      }

      protected NotFoundException(SerializationInfo info, StreamingContext context) : base(typeof(NotFoundException).Name, StatusValue, info, context)
      {
      }
   }
}
