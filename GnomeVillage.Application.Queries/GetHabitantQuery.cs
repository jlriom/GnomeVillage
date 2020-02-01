using GnomeVillage.Application.Queries.dto;
using GnomeVillage.Cqrs.Contracts;

namespace GnomeVillage.Application.Queries
{
   public class GetHabitantQuery : IQuery<Habitant>
   {
      public GetHabitantQuery(string id)
      {
         Id = id;
      }

      public string Id { get; }
   }
}
