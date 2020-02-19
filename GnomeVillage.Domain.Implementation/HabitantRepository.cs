using AutoMapper;
using GnomeVillage.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GnomeVillage.Domain.Implementation
{
   public class HabitantRepository : Repository<Data.Models.Habitant, int, Habitant, HabitantId>, IHabitantRepository
   {
      public HabitantRepository(GnomeVillageContext context, IMapper mapper) : base(context, mapper)
      {
      }

      public override async Task<Habitant> UpdateAsync(HabitantId keyValue, Habitant domainEntity)
      {
         var id = Mapper.Map<int>(keyValue);

         var habitant = await DbSet
            .Include(h => h.HairColor)
            .Include(h => h.HabitantProfessions)
            .FirstOrDefaultAsync(h => h.Id == id);

         if (habitant == null)
            throw new KeyNotFoundException(typeof(Habitant).Name);

         habitant.Age = domainEntity.Age;
         habitant.HairColorId = domainEntity.HairColor.Id;
         habitant.Name = domainEntity.Name;
         habitant.Weight = domainEntity.Weight;
         habitant.Height = domainEntity.Height;
         habitant.Thumbnail = domainEntity.Thumbnail.ToString();
         
         UpdateProfessions(domainEntity, habitant);

         DbSet.Update(habitant);
         await Context.SaveChangesAsync().ConfigureAwait(false);
         return domainEntity;

      }

      private  void UpdateProfessions(Habitant domainEntity, Data.Models.Habitant habitant)
      {
         foreach (var profession in habitant.HabitantProfessions)
         {
            if (!domainEntity.Professions.Contains(new Profession(new ProfessionId(profession.ProfessionId))))
            {
               Context.Entry(profession).State = EntityState.Deleted;
            }
         }

         foreach (var profession in domainEntity.Professions)
         {
            var professionEntity = habitant.HabitantProfessions.FirstOrDefault(p => p.ProfessionId == profession.Id);
            if (professionEntity == null)
            {
               habitant.HabitantProfessions.Add(new Data.Models.HabitantProfessions
               {
                  HabitantId = habitant.Id,
                  ProfessionId = profession.Id
               });
            }
            else
            {
               habitant.HabitantProfessions.Remove(professionEntity);
            }
         }
      }
   }
}
