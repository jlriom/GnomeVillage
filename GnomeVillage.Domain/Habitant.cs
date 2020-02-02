using GnomeVillage.Domain.Core;
using System;
using System.Collections.Generic;

namespace GnomeVillage.Domain
{
   public class Habitant: Entity<HabitantId>
   {
      public HabitantName Name { get; set; }
      public Uri Thumbnail { get; set; }
      public int Age { get; }
      public decimal Weight { get; set; }
      public decimal Height { get; set; }
      public HairColor HairColor { get; set; }
      public IList<Profession> Professions { get; set; }
      public IList<HabitantName> Friends { get; set; }

      protected override void EnsureValidState()
      {
         if (Name == null || (Name!= null && string.IsNullOrEmpty(Name.Value)))
         {
            BrokenRules.Add(new BrokenRule("Name has to be defined"));
         }

         if (Thumbnail == null || (Name != null && Thumbnail.IsWellFormedOriginalString()))
         {
            BrokenRules.Add(new BrokenRule("Thumbnail has to be defined"));
         }

         if (Weight < 0)
         {
            BrokenRules.Add(new BrokenRule("Weight has to be a positive number"));
         }

         if (Height < 0)
         {
            BrokenRules.Add(new BrokenRule("Height has to be a positive number"));
         }

         if (HairColor == null)
         {
            BrokenRules.Add(new BrokenRule("HairColor has to be defined"));
         }
      }
   }
}
