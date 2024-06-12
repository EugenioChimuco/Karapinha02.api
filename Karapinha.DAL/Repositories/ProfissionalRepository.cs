using Karapinha.Model;
using Karapinha.Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DAL.Repositories
{
    public class ProfissionalRepository : GenericRepository<Profissional>, IProfissionalRepository
    {
        private readonly KarapinhaContext _karapinhaContext;
        public ProfissionalRepository(KarapinhaContext karapinhaContext) : base(karapinhaContext)
        {
            _karapinhaContext = karapinhaContext;
        }
    }
}
