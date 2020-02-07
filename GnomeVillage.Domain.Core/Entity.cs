
using System.Collections.Generic;

namespace GnomeVillage.Domain.Core
{
   public abstract class Entity<TKey>
   {
      public TKey Id { get; }

      private IList<BrokenRule> BrokenRules { get; } = new List<BrokenRule>();

      protected abstract void EnsureValidState();

      protected Entity(TKey id)
      {
         this.Id = id;
      }

      public void AddBrokenRule(string brokenRuleDescription)
      {
         BrokenRules.Add(new BrokenRule(brokenRuleDescription));
      }

      public void Validate(string message)
      {
         EnsureValidState();

         if (BrokenRules.Count> 0)
         {
            throw new DomainException(message, BrokenRules);
         }
      }
   }
}
