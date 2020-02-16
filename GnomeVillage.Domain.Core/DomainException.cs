using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GnomeVillage.Domain.Core
{

   [Serializable]
   [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3925:\"ISerializable\" should be implemented correctly", Justification = "<Pending>")]
   public sealed class DomainException : ApplicationException
   {
      [NonSerialized]
      private const int StatusValue = 400;

      public string Type { get; }
      public string Title { get; }
      public int Status { get; } 
      public string Detail { get; }
      public string Instance { get; }

      public DomainException() : base()
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

      public DomainException(string message, Exception innerException) : base(message, innerException)
      {
         Status = StatusValue;
         Type = typeof(DomainException).Name;
         Title = message;
      }

      public DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
      {
         Status = StatusValue;
         Type = typeof(DomainException).Name;
      }

      public override void GetObjectData(SerializationInfo info, StreamingContext context)
      {
         if (info == null)
         {
            throw new ArgumentNullException("info");
         }
         info.AddValue("Type", Type);
         info.AddValue("Title", Title);
         info.AddValue("Status", Status);
         info.AddValue("Detail", Detail);
         info.AddValue("Instance", Instance);

         base.GetObjectData(info, context);
      }
   }
}
