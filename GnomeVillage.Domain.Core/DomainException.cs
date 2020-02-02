using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GnomeVillage.Domain.Core
{

   [Serializable]
   public sealed class DomainException : ApplicationException
   {
      private const int StatusValue = 400;

      public string Type { get; }
      public string Title { get; }
      public int Status { get; } 
      public string Detail { get; }
      public string Instance { get; }

      private DomainException():base()
      {
         Status = StatusValue;
         Type = typeof(DomainException).Name;
      }

      public DomainException(string message, IEnumerable<BrokenRule> brokenRules) : base(message)
      {
      
         Status = StatusValue;
         Type = typeof(DomainException).Name;
         Title = message;

         foreach (var brokenRule in brokenRules)
         {
            this.Data.Add(brokenRule, brokenRule.Description);
         }
      }

      private DomainException(string message, Exception innerException) : base(message, innerException)
      {
         Status = StatusValue;
         Type = typeof(DomainException).Name;
         Title = message;
      }

      private DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
      {
         Status = StatusValue;
         Type = typeof(DomainException).Name;
      }
   }
}
