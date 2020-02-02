using System;
using System.Runtime.Serialization;

namespace GnomeVillage.Application.Common.Exceptions
{

   [Serializable]
   public class AppException : ApplicationBaseException
   {
      private const int StatusValue = 400;

      public AppException(): base(typeof(AppException).Name, StatusValue)
      {
      }

      public AppException(string message) : base(typeof(AppException).Name, StatusValue, message)
      {
      }

      public AppException(string message, Exception innerException) : base(typeof(AppException).Name, StatusValue, message, innerException)
      {
      }

      protected AppException(SerializationInfo info, StreamingContext context) : base(info, context)
      {
      }
   }
}
