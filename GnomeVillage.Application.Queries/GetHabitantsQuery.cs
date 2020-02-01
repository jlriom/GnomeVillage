using GnomeVillage.Application.Queries.dto;
using GnomeVillage.Cqrs.Implementation;

namespace GnomeVillage.Application.Queries
{
   public class GetHabitantsQuery: PagedQuery<Habitant>
   {
      public GetHabitantsQuery(int limit, int offset): base(limit, offset)
      {
      }
   }
}
