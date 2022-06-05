using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conduit.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Data.Repositories
{
    public abstract class BaseRepository<TDbModel, TDomainModel> : IBaseRepository<TDomainModel>
        where TDbModel : class, IDbModel
        where TDomainModel : class, IDomainModel
    {
        private readonly AppDbContext _context;
        private readonly Mapper _mapper;

        public BaseRepository(AppDbContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        protected AppDbContext Context
        {
            get
            {
                _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                return _context;
            }
        }
        protected Mapper Mapper => _mapper;


        public async Task CreateRecordAsync(TDomainModel record)
        {
            var dbModel = Mapper.Map<TDomainModel, TDbModel>(record);
            var dbEntity = Context.Add(dbModel);
            await Context.SaveChangesAsync();
            Mapper.Map(dbModel, record);
        }

        public async Task CreateRecordsAsync(List<TDomainModel> records, bool returnIds = true)
        {
            var dbModels = records.Select(record => Mapper.Map<TDomainModel, TDbModel>(record)).ToList();

            await Context.AddRangeAsync(dbModels);
            for (var i = 0; i < records.Count; i++)
                Mapper.Map(dbModels[i], records[i]);
            var domainModels = dbModels.Select(record => Mapper.Map<TDbModel, TDomainModel>(record)).ToList();
            await Context.SaveChangesAsync();
        }

        public async Task DeleteRecordAsync(TDomainModel record)
        {
            var dbModel = Mapper.Map<TDomainModel, TDbModel>(record);
            var dbEntity = Context.Update(dbModel);

            await Context.SaveChangesAsync();
        }

        public async Task DeleteRecordsAsync(List<TDomainModel> records)
        {
            var dbModels = records.Select(record => Mapper.Map<TDomainModel, TDbModel>(record)).ToList();
            Context.UpdateRange(dbModels);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateRecordAsync(TDomainModel record)
        {
            var dbModel = Mapper.Map<TDomainModel, TDbModel>(record);
            Context.Remove(dbModel);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateRecordsAsync(List<TDomainModel> records)
        {
            var dbModels = records.Select(record => Mapper.Map<TDomainModel, TDbModel>(record)).ToList();
            Context.RemoveRange(dbModels);
            await Context.SaveChangesAsync();
        }
    }
}
