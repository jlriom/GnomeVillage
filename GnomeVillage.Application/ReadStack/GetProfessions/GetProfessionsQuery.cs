using GnomeVillage.Cqrs.Contracts;
using System.Collections.Generic;

namespace GnomeVillage.Application.ReadStack.GetProfessions
{
   public class GetProfessionsQuery: IQuery<IEnumerable<string>>
   {
   }
}
