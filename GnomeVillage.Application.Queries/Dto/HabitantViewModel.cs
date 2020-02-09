namespace GnomeVillage.Application.Queries.Dto
{
   public class HabitantViewModel
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Thumbnail { get; set; }
      public int Age { get; set; }
      public decimal Weight { get; set; }
      public decimal Height { get; set; }
      public string HairColor { get; set; }
      public string[] Professions { get; set; }
      public string[] Friends { get; set; }
   }
}
