using GnomeVillage.Domain.Core;

namespace GnomeVillage.Domain
{
   public class Profession : ValueObject<Profession>
   {
      public Profession(ProfessionId id)
      {
         Id = id;
      }
      public ProfessionId Id { get; }
   }
}
