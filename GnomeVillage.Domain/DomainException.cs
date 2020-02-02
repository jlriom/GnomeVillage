using System;
using System.Runtime.Serialization;

namespace GnomeVillage.Domain
{

   [Serializable]
   public class DomainException : ApplicationException
   {
      private const int StatusValue = 400;

      public string Type { get; }
      public string Title { get; }
      public int Status { get; } 
      public string Detail { get; }
      public string Instance { get; }

      public DomainException()
      {
         Status = StatusValue;
         Type = typeof(DomainException).Name;
      }

      public DomainException(string message) : base(message)
      {
         Status = StatusValue;
         Type = typeof(DomainException).Name;
         Title = message;
      }

      public DomainException(string message, Exception innerException) : base(message, innerException)
      {
         Status = StatusValue;
         Type = typeof(DomainException).Name;
         Title = message;
      }

      protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
      {
         Status = StatusValue;
         Type = typeof(DomainException).Name;
      }
   }
}
