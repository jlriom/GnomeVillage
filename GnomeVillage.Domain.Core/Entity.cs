
using System.Collections.Generic;

namespace GnomeVillage.Domain.Core
{
   public abstract class Entity<TKey>
   {
      public TKey Id { get; }

      public IList<BrokenRule> BrokenRules { get; } = new List<BrokenRule>();

      protected abstract void EnsureValidState();

      public void Validate(string message, ICollection<BrokenRule> brokenRules)
      {
         EnsureValidState();

         foreach (var brokenRule in brokenRules)
            BrokenRules.Add(brokenRule);

         if (BrokenRules.Count> 0)
         {
            throw new DomainException(message, BrokenRules);
         }
      }

      public void Validate(string message)
      {
         Validate(message, new List<BrokenRule>());
      }
   }
}
