using GnomeVillage.Domain.Core;

namespace GnomeVillage.Domain
{
   public class Profession : ValueObject<Profession>
   {
      public ProfessionId Id { get; } 
   }
}
