using Karapinha.DTO;
using Karapinha.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Shared.IService
{
    public interface IUtilizadorService
    {
        Task<Utilizador> MostrarUtilizadorPorId(int id);
        Task<Utilizador> MostrarPorUsername(string username);
        Task<List<Utilizador>> ListarTodosUsuarios();
        Task<bool> AtualizarDadosDoUtilizador(int id, UtilizadorAtualizarDTO utilizadorAtualizarDTO);
        Task<bool> AdicionarUtilizador(UtilizadorAdicionarDTO utilizadorAdicionarDTO);
        Task<bool> ApagarUtilizador(int id);
        Task <bool> AtivarUtilizador(int id);
        Task<bool> Bloquear_e_DesbloquearConta(int id);
        Task<Utilizador> Login(string username, string password);
        
    
    }
}
