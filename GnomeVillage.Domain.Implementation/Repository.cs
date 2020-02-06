using AutoMapper;
using CSharpFunctionalExtensions;
using GnomeVillage.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GnomeVillage.Domain.Implementation
{
   public abstract class Repository<T, TDomainEntity, Tkey>
      where T : class
      where TDomainEntity : class
   {
      private readonly DbSet<T> dbSet;
      private readonly GnomeVillageContext context;
      protected readonly IMapper Mapper;

      protected Repository(GnomeVillageContext context, IMapper mapper)
      {
         this.context = context;
         dbSet = this.context.Set<T>();
         Mapper = mapper;
      }

      public virtual async Task<IList<TDomainEntity>> GetAllAsync()
      {
         return await Task.FromResult(Mapper.Map<IList<TDomainEntity>>(dbSet.ToList()));
      }

      public virtual async Task<IEnumerable<TDomainEntity>> GetAsync(Func<T, bool> predicate)
      {
         var entities = dbSet.Where(predicate).Select(Mapper.Map<TDomainEntity>);
         return await Task.FromResult(entities);
      }

      public virtual async Task<Maybe<TDomainEntity>> FindAsync(Tkey keyValue)
      {
         var entity = await dbSet.FindAsync(keyValue);
         return entity == null ? Maybe<TDomainEntity>.From(Mapper.Map<TDomainEntity>(entity)) : Maybe<TDomainEntity>.None;
      }

      public async Task<TDomainEntity> DeleteAsync(TDomainEntity domainEntity)
      {
         dbSet.Remove(Mapper.Map<T>(domainEntity));
         await context.SaveChangesAsync().ConfigureAwait(false);
         return domainEntity;
      }

      public async Task<TDomainEntity> InsertAsync(TDomainEntity domainEntity)
      {
         dbSet.Add(Mapper.Map<T>(domainEntity));
         await context.SaveChangesAsync().ConfigureAwait(false);
         return domainEntity;
      }

      public async Task<TDomainEntity> UpdateAsync(TDomainEntity domainEntity)
      {
         dbSet.Update(Mapper.Map<T>(domainEntity));
         await context.SaveChangesAsync().ConfigureAwait(false);
         return domainEntity;
      }

   }
}
