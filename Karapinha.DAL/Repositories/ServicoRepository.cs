using Karapinha.Model;
using Karapinha.Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DAL.Repositories
{
    public class ServicoRepository : GenericRepository<Servico>, IServicoRepository
    {
        public ServicoRepository(KarapinhaContext karapinhaContext) : base(karapinhaContext)
        {
        }
    }
}
