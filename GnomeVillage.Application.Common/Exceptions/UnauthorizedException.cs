using System;
using System.Runtime.Serialization;

namespace GnomeVillage.Application.Common.Exceptions
{
   [Serializable]
   public class UnauthorizedException : ApplicationBaseException
   {

      private const int StatusValue = 401;

      public UnauthorizedException() : base(typeof(UnauthorizedException).Name, StatusValue)
      {
      }

      public UnauthorizedException(string message) : base(typeof(UnauthorizedException).Name, StatusValue, message)
      {
      }

      public UnauthorizedException(string message, Exception innerException) : base(typeof(UnauthorizedException).Name, StatusValue, message, innerException)
      {
      }

      protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
      {
      }
   }
}
