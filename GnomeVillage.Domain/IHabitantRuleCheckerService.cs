namespace GnomeVillage.Domain
{
   public interface IHabitantRuleCheckerService
   {
      void CheckForInsert(Habitant habitant);
      void CheckForUpdate(Habitant habitant);
      void CheckForDelete(Habitant habitant);
   }
}
