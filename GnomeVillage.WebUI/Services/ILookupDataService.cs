using System.Collections.Generic;
using System.Threading.Tasks;

namespace GnomeVillage.WebUI.Services
{
   public interface ILookupDataService
   {
      Task<IEnumerable<string>> GetAllHairColors();
      Task<IEnumerable<string>> GetAllProfessions();
   }
}
