using PostgreSql.Core.Utilities.Results;
using PostgreSql.Entities.Concrate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgreSql.Business.Abstract
{
    public interface IExampleService
    {
        Task<IDataResult<List<Example>>> GetAllAsync();
        Task<IDataResult<Example>> GetByIdAsync(int id);
        Task<IResult> AddAsync(Example example);
        Task<IResult> UpdateAsync(Example example);
        Task<IResult> DeleteAsync(Example example);
    }
}
