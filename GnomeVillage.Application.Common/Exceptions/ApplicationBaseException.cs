using System;
using System.Runtime.Serialization;

namespace GnomeVillage.Application.Common.Exceptions
{
   [Serializable]
   public abstract class ApplicationBaseException: ApplicationException
   {

      public string Type { get; set; }
      public string Title { get; }
      public int Status { get; set; }
      public string Detail { get; }
      public string Instance { get; }

      protected ApplicationBaseException(string @type, int status)
      {
         Type = @type;
         Status = status;
      }

      protected ApplicationBaseException(string @type, int status, string message) : base(message)
      {
         Type = @type;
         Status = status;
         Title = message;
      }

      protected ApplicationBaseException(string @type, int status, string message, Exception innerException) : base(message, innerException)
      {
         Type = @type;
         Status = status;
         Title = message;
         Detail = innerException.Message;
         Instance = innerException.ToString();
      }

      protected ApplicationBaseException(string @type, int status, SerializationInfo info, StreamingContext context) : base(info, context)
      {
      }
   }
}
