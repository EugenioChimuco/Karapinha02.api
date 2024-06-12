using Karapinha.Model;
using Karapinha.Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DAL.Repositories
{
    public class HorarioFuncionarioRepository : GenericRepository<HorarioFuncionario>, IHoraFuncionarioRepository
    {
        public HorarioFuncionarioRepository(KarapinhaContext karapinhaContext) : base(karapinhaContext)
        {
        }
    }
}
