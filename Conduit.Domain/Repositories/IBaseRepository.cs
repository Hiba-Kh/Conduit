using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Domain.Repositories
{
    public interface IBaseRepository<TDomainModel>
    {
        public Task CreateRecordAsync(TDomainModel record);
        public Task CreateRecordsAsync(List<TDomainModel> records, bool returnIds = true);
        public Task UpdateRecordAsync(TDomainModel record);
        public Task UpdateRecordsAsync(List<TDomainModel> records);
        public Task DeleteRecordAsync(TDomainModel record);
        public Task DeleteRecordsAsync(List<TDomainModel> records);
 
    }
}
