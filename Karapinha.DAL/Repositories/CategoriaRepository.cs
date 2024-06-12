using Karapinha.Model;
using Karapinha.Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DAL.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(KarapinhaContext karapinhaContext) : base(karapinhaContext)
        {
        }
    }
}
