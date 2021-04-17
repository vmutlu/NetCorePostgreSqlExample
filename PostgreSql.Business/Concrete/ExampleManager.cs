using PostgreSql.Business.Abstract;
using PostgreSql.Core.Utilities.Results;
using PostgreSql.DataAccess.Abstract;
using PostgreSql.Entities.Concrate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgreSql.Business.Concrete
{
    public class ExampleManager : IExampleService
    {
        private readonly IExampleRepository _exampleRepository;
        public ExampleManager(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<IResult> AddAsync(Example example)
        {
            await _exampleRepository.AddAsync(example);

            return new SuccessResult($"{example.Title} başlıklı Örnek Veri Başarıyla Eklenmiştir.");
        }

        public async Task<IResult> DeleteAsync(Example example)
        {
            var deleted = await _exampleRepository.GetAsync(i => i.Id == example.Id);
            if (deleted != null)
            {
                await _exampleRepository.DeleteAsync(deleted);
                return new SuccessResult($"{example} Id'sine sahip Örnek Veri Başarıyla Silinmiştir.");
            }

            else
                return new ErrorResult($"{example.Id} Id'sine sahip Örnek Veri Bulunamadığı için silme işlemi başarısız oldu.");
        }

        public async Task<IDataResult<List<Example>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Example>>(await _exampleRepository.GetAllAsync());
        }

        public async Task<IDataResult<Example>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Example>(await _exampleRepository.GetAsync(c => c.Id == id));
        }

        public async Task<IResult> UpdateAsync(Example example)
        {
            var updated = await _exampleRepository.GetAsync(i => i.Id == example.Id);
            if (updated != null)
            {
                updated.Title = example.Title;
                updated.Description = example.Description;
                await _exampleRepository.UpdateAsync(updated);

                return new SuccessResult("Örnek Veri Başarıyla Güncellenmiştir.");
            }

            else
                return new ErrorResult($"{example.Id} Id'sine sahip Örnek Veri Bulunamadığı için güncelleme işlemi başarısız oldu.");
        }
    }
}
