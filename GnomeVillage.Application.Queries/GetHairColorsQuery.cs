using GnomeVillage.Cqrs.Contracts;
using System.Collections.Generic;

namespace GnomeVillage.Application.Queries
{
   public class GetHairColorsQuery : IQuery<IEnumerable<string>>
   {
   }
}
