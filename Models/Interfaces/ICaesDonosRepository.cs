using Test.Models.ManyToMany;
using System.Threading.Tasks;

namespace Test.Models.Interfaces
{
    public interface ICaesDonosRepository
    {
        Task<CaesDono> Insert(CaesDono caesDono);        
        Task Remove(int caesId, int donosId);
    }
}