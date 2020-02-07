using GnomeVillage.Domain.Core;
using System;
using System.Collections.Generic;

namespace GnomeVillage.Domain
{
   public class Habitant : Entity<HabitantId>
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
         if (Name == null || (Name != null && string.IsNullOrEmpty(Name.Value)))
            AddBrokenRule("Name has to be defined");

         if (Thumbnail == null || (Name != null && Thumbnail.IsWellFormedOriginalString()))
            AddBrokenRule("Thumbnail has to be defined");

         if (Weight < 0)
            AddBrokenRule("Weight has to be a positive number");

         if (Height < 0)
            AddBrokenRule("Height has to be a positive number");

         if (HairColor == null)
            AddBrokenRule("HairColor has to be defined");
      }
   }
}
