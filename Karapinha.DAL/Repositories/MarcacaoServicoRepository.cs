using Karapinha.Model;
using Karapinha.Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DAL.Repositories
{
    public class MarcacaoServicoRepository : GenericRepository<MarcacaoServico>, IMarcacaoServicoRepository
    {
        public MarcacaoServicoRepository(KarapinhaContext karapinhaContext) : base(karapinhaContext)
        {
        }
    }
}
