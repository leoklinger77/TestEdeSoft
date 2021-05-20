using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public Task<List<CaesDono>> FindByCaes(int id)
        {
            return _context.CaesDono.Where(x => x.CaesId == id).AsNoTracking().ToListAsync();
        }

        public Task<List<CaesDono>> FindByDonos(int id)
        {
            return _context.CaesDono.Where(x => x.DonosId == id).AsNoTracking().ToListAsync();
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
