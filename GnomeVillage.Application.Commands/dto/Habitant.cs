namespace GnomeVillage.Application.Commands.Dto
{
   public class Habitant
   {
      public string Name { get; set; }
      public string Thumbnail { get; set; }
      public int Age { get; set; }
      public decimal Weight { get; set; }
      public decimal Height { get; set; }
      public string HairColor { get; set; }
      public string[] Professions { get; set; }
   }
}
