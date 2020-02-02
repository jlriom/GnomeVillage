using System;
using System.Collections.Generic;

namespace GnomeVillage.Domain
{
   public class Habitant
   {
      public HabitantId Id { get; set; }
      public HabitantName Name { get; set; }
      public Uri Thumbnail { get; set; }
      public int Age { get; }
      public decimal Weight { get; set; }
      public decimal Height { get; set; }
      public HairColor HairColor { get; set; }
      public IList<Profession> Professions { get; set; }
      public IList<HabitantName> Friends { get; set; }
   }
}
