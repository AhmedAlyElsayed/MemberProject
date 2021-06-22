using System.Threading.Tasks;

namespace MemberProject.UOW
{
    public interface IUnitOfWork<T>
    {
        int Commit();
        ValueTask<int> CommitAsync();
    }
}
