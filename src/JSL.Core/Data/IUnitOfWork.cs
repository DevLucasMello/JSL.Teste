using System.Threading.Tasks;

namespace JSL.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
