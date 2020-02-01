using GnomeVillage.Cqrs.Contracts;
using System.Collections.Generic;

namespace GnomeVillage.Application.ReadStack.GetHairColors
{
   public class GetHairColorsQuery: IQuery<IEnumerable<string>>
   {
   }
}
