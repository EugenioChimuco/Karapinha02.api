using Karapinha.Model;
using Karapinha.Shared.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.DAL.Repositories
{
    public class UtilizadorRepository : GenericRepository<Utilizador>, IUtilizadorRepository
    {
        private readonly KarapinhaContext _karapinhaContext;
        public UtilizadorRepository(KarapinhaContext karapinhaContext) : base(karapinhaContext)
        {
            _karapinhaContext = karapinhaContext;
        }

        public async Task<Utilizador> MostrarPorUsername(string username)
        {
            return await _karapinhaContext.Utilizadores.FirstOrDefaultAsync(u => u.UserName == username);
        }




    }
}
