
using GnomeVillage.Domain.Core;

namespace GnomeVillage.Domain
{
   public class HairColor : ValueObject<HairColor>
   {
      public HairColor(HairColorId id)
      {
         Id = id;
      }
      public HairColorId Id { get; }
   }
}
