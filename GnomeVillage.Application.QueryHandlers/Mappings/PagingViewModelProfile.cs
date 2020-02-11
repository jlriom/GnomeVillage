using AutoMapper;
using GnomeVillage.Cqrs.Implementation;


namespace GnomeVillage.Application.QueryHandlers.Mappings
{
   public class PagingViewModelProfile: Profile
   {

      public PagingViewModelProfile()
      {
         CreateMap(typeof(ReadModel.Contracts.Models.Paging<>), typeof(Paging<>));
      }
   }
}
