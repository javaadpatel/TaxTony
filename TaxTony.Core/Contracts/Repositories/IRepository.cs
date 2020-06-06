using System.Threading.Tasks;

namespace TaxTony.Core.Contracts.Repositories
{
    public interface IRepository<T>
    {
        Task<T> CreateAsync(T item);
    }
}
