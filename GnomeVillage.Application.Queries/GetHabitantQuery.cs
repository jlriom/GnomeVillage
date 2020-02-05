using GnomeVillage.Application.Queries.Dto;
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
