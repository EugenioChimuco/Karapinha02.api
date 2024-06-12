using Karapinha.Model;
using Karapinha.Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DAL.Repositories
{
    public class HorarioRepository : GenericRepository<Horario>, IHorarioRepository
    {
        public HorarioRepository(KarapinhaContext karapinhaContext) : base(karapinhaContext)
        {
        }
    }
}
