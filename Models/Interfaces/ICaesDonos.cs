using Test.Models.ManyToMany;
using System.Threading.Tasks;

namespace Test.Models.Interfaces
{
    public interface ICaesDonos
    {
        Task<CaesDono> Insert(CaesDono caesDono);        
        Task Remove(int id);
    }
}