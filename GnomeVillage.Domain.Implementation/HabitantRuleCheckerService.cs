using System.Threading.Tasks;

namespace GnomeVillage.Domain.Implementation
{
   public class HabitantRuleCheckerService : IHabitantRuleCheckerService
   {
      private readonly IHabitantReadOnlyRepository habitantReadOnlyRepository;
      private readonly IHairColorReadonlyRepository hairColorReadonlyRepository;
      private readonly IProfessionReadonlyRepository professionReadonlyRepository;

      public HabitantRuleCheckerService(
         IHabitantReadOnlyRepository habitantReadOnlyRepository,
         IHairColorReadonlyRepository hairColorReadonlyRepository,
         IProfessionReadonlyRepository professionReadonlyRepository)
      {
         this.habitantReadOnlyRepository = habitantReadOnlyRepository;
         this.hairColorReadonlyRepository = hairColorReadonlyRepository;
         this.professionReadonlyRepository = professionReadonlyRepository;
      }
      public async Task<Habitant> CheckForDeleteAsync(Habitant habitant)
      {
         throw new System.NotImplementedException();
      }

      public async Task<Habitant> CheckForInsertAsync(Habitant habitant)
      {
         throw new System.NotImplementedException();
      }

      public async Task<Habitant> CheckForUpdateAsync(Habitant habitant)
      {
         throw new System.NotImplementedException();
      }
   }
}
