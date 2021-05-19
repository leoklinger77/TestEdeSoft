using Test.Data;
using Test.Models;
using Test.Models.Interfaces;

namespace Test.Repository
{
    public class DonosRepository : Repository<Donos>, IDonosRepository
    {
        public DonosRepository(DataContext context) : base(context)
        {
        }
    }
}
