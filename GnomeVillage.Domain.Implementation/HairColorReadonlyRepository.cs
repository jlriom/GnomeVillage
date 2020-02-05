using AutoMapper;
using GnomeVillage.Data;

namespace GnomeVillage.Domain.Implementation
{
   public class HairColorReadonlyRepository : Repository<Data.Models.HairColor, HairColor, HairColorId>, IHairColorReadonlyRepository
   {
      public HairColorReadonlyRepository(GnomeVillageContext context, IMapper mapper) : base(context, mapper)
      {
      }
   }
}
