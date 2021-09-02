using System.Threading.Tasks;

namespace FizzBook.Areas.Repository
{
    public interface IGenericRepository
    {
        Task<bool> Add(object EntityType);
        Task<bool> Delete(object EntityType);
        Task<bool> Update(object EntityType);
    }
}