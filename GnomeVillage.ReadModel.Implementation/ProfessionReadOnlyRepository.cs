using AutoMapper;
using GnomeVillage.Data;
using GnomeVillage.ReadModel.Contracts;
using GnomeVillage.ReadModel.Contracts.Models;

namespace GnomeVillage.ReadModel.Implementation
{
   public class ProfessionReadOnlyRepository : ReadonlyBaseRepository<Data.Models.Profession, Profession>, IProfessionReadOnlyRepository
   {
      public ProfessionReadOnlyRepository(GnomeVillageContext context, IMapper mapper) : base(context, mapper)
      {
      }
   }
}
