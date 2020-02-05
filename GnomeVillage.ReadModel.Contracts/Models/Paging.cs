using System.Collections.Generic;

namespace GnomeVillage.ReadModel.Contracts.Models
{
   public class Paging<T>
   {
      public IEnumerable<T> Items { get; set; }
      public int Limit { get; set; }
      public int Offset { get; set; }
      public int Total { get; set; }

      public Paging(IEnumerable<T> items, int limit, int offset, int total)
      {
         Items = items;
         Limit = limit;
         Offset = offset;
         Total = total;
      }
   }
}
