namespace GnomeVillage.ReadModel.Contracts.Models
{
   public class Profession
    {
      public string Name { get; set; }
      public override string ToString()
      {
         return Name;
      }
   }
}
