using AutoMapper;
using GnomeVillage.Data;

namespace GnomeVillage.Domain.Implementation
{
   public class ProfessionReadonlyRepository : Repository<Data.Models.Profession, Profession, ProfessionId>, IProfessionReadonlyRepository
   {
      public ProfessionReadonlyRepository(GnomeVillageContext context, IMapper mapper) : base(context, mapper)
      {
      }
   }
}
