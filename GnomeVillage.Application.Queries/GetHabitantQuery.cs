using GnomeVillage.Application.Queries.Dtos;
using GnomeVillage.Cqrs.Contracts;

namespace GnomeVillage.Application.Queries
{
   public class GetHabitantQuery : IQuery<HabitantViewModel>
   {
      public GetHabitantQuery(int id)
      {
         Id = id;
      }

      public int Id { get; }
   }
}
