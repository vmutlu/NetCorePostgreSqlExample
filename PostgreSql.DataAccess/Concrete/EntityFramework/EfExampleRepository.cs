using PostgreSql.Core.DataAccess.EntityFramework;
using PostgreSql.DataAccess.Abstract;
using PostgreSql.Entities.Concrate;

namespace PostgreSql.DataAccess.Concrete.EntityFramework
{
    public class EfExampleRepository : EfEntityRepositoryBase<Example, ExampleContext>, IExampleRepository
    {
    }
}
