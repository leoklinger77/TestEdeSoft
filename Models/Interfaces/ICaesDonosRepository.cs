using Test.Models.ManyToMany;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Test.Models.Interfaces
{
    public interface ICaesDonosRepository
    {
        Task<CaesDono> Insert(CaesDono caesDono);        
        Task Remove(int caesId, int donosId);
        Task<List<CaesDono>> FindByCaes(int id);
        Task<List<CaesDono>> FindByDonos(int id);
        
    }
}