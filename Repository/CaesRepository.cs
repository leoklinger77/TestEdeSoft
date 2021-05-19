using Test.Data;
using Test.Models;
using Test.Models.Interfaces;

namespace Test.Repository
{
    public class CaesRepository : Repository<Caes>, ICaesRepository
    {
        public CaesRepository(DataContext context) : base(context) { }

    }
}
