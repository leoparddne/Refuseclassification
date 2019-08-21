using Repository.DbContexts;
using Repository.Entity;
using Repository.IRepository;

namespace Repository.Repository
{
    public class RecordTypeRepository : RepositoryBase<recordType>, IRecordTypeRepository
    {
        public RecordTypeRepository(CommonContext context) : base(context)
        {
        }
    }
}