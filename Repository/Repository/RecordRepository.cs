using Repository.DbContexts;
using Repository.Entity;
using Repository.IRepository;

namespace Repository.Repository
{
    public class RecordRepository : RepositoryBase<record>, IRecordRepository
    {
        public RecordRepository(CommonContext context) : base(context)
        {
        }
    }
}
