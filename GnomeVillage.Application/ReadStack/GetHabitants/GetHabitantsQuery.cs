using GnomeVillage.Application.Common;
using GnomeVillage.Cqrs.Implementation;

namespace GnomeVillage.Application.ReadStack.GetHabitants
{
   public class GetHabitantsQuery: PagedQuery<Habitant>
   {
      public GetHabitantsQuery(int limit, int offset): base(limit, offset)
      {
      }
   }
}
