using GnomeVillage.Application.Common;
using GnomeVillage.Cqrs.Contracts;

namespace GnomeVillage.Application.ReadStack.GetHabitant
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
