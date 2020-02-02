namespace GnomeVillage.Domain
{
   public interface IHabitantRepository
   {
      void Insert(Habitant habitant);
      void Update(Habitant habitant);
      void Delete(Habitant habitant);
   }
}
