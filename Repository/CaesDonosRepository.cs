using System.Threading.Tasks;
using Test.Data;
using Test.Models.Interfaces;
using Test.Models.ManyToMany;

namespace Test.Repository
{
    public class CaesDonosRepository : ICaesDonosRepository
    {
        private readonly DataContext _context;
        public CaesDonosRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<CaesDono> Insert(CaesDono caesDono)
        {
            _context.CaesDono.Add(caesDono);
            await _context.SaveChangesAsync();
            return caesDono;
        }

        public async Task Remove(int caesId, int donosId)
        {
            _context.CaesDono.Remove(new CaesDono {CaesId = caesId, DonosId= donosId });
            await _context.SaveChangesAsync();
        }
    }
}
