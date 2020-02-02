using System;
using System.Collections.Generic;
using System.Text;

namespace GnomeVillage.Domain.Core
{
   public abstract class Entity<TKey>
   {
      public TKey Id { get; }

      public IList<BrokenRule> BrokenRules { get; }

      protected abstract void EnsureValidState();

      protected void Validate(string message)
      {
         EnsureValidState();
         if (BrokenRules.Count> 0)
         {
            throw new DomainException(message, BrokenRules);
         }
      }

   }
}
