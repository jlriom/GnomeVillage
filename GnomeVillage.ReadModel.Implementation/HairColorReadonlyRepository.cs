using AutoMapper;
using GnomeVillage.Data;
using GnomeVillage.ReadModel.Contracts;
using GnomeVillage.ReadModel.Contracts.Models;

namespace GnomeVillage.ReadModel.Implementation
{
   public class HairColorReadonlyRepository: ReadonlyBaseRepository<Data.Models.HairColor, HairColor>, IHairColorReadonlyRepository
   {
      public HairColorReadonlyRepository(GnomeVillageContext context, IMapper mapper): base(context, mapper)
      {
      }
   }
}
