using GnomeVillage.Application.Queries.Dto;
using GnomeVillage.Cqrs.Implementation;

namespace GnomeVillage.Application.Queries
{
   public class GetHabitantsQuery : PagedQuery<HabitantViewModel>
   {
      public GetHabitantsQuery(int limit, int offset) : base(limit, offset)
      {
      }
   }
}
