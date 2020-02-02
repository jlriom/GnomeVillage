using CSharpFunctionalExtensions;
using GnomeVillage.Data;
using GnomeVillage.ReadModel.Contracts;
using GnomeVillage.ReadModel.Contracts.Models;
using System.Threading.Tasks;

namespace GnomeVillage.ReadModel.Implementation
{
   public class HabitantReadOnlyRepository : IHabitantReadOnlyRepository
   {

      private readonly GnomeVillageContext Context;

      public HabitantReadOnlyRepository(GnomeVillageContext context)
      {
         Context = context;
      }

      public async Task<Maybe<Habitant>> GetSingleAsync(int habitantId)
      {
         var habitant = await Context.Habitant.FindAsync(habitantId);
         
         return habitant == null ? Maybe<Habitant>.From(new Habitant()) : Maybe<Habitant>.None;
      }
   }
}
