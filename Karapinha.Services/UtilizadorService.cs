using Karapinha.DTO;
using Karapinha.Model;
using Karapinha.Shared.IRepository;
using Karapinha.Shared.IService;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Karapinha.Services
{
    public class UtilizadorService : IUtilizadorService
    {
        private readonly IUtilizadorRepository _utilizadorRepository;
        private readonly IEmailService _emailService;
        private readonly string _adminEmail;

        public UtilizadorService(IUtilizadorRepository utilizadorRepository, IEmailService emailService)
        {
            _utilizadorRepository = utilizadorRepository;
            _emailService = emailService;
            _adminEmail = "chimuco007@gmail.com"; 
        }

        public async Task<bool> AdicionarUtilizador(UtilizadorAdicionarDTO utilizadorAdicionarDTO)
        {
            var utilizador = new Utilizador()
            {
                NomeCompleto = utilizadorAdicionarDTO.NomeCompleto,
                Email = utilizadorAdicionarDTO.Email,
                BI = utilizadorAdicionarDTO.Bi,
                Phone = utilizadorAdicionarDTO.Phone,
                FotoPath = utilizadorAdicionarDTO.FotoPath,
                Password = utilizadorAdicionarDTO.Password,
                TipoDeUser = utilizadorAdicionarDTO.TipoDeUser,
                UserName = utilizadorAdicionarDTO.UserName,
            };

            bool criado = await _utilizadorRepository.Criar(utilizador);
            if (!criado)
            {
                return false;
            }

            // Enviar email para o administrativo
            if (utilizador.TipoDeUser == 2) {
                string subject = "Criação de conta Administrativa";
                string body = "Bem-vindo ao Karapinha \n" +
                                " Foi registrado como Administrador.\n" +
                                " Os seus dados de acesso são:"+
                                $"Username :{utilizador.UserName}\n" +
                                $"Senha    :{utilizador.Password}";
                await _emailService.SendEmailAsync(utilizador.Email,subject,body);       
            }
            else
            {
                // Enviar email ao administrador
                await EnviarEmailParaAdministrador(utilizador);
            }

            return true;
        }

        public async Task<bool> ApagarUtilizador(int id)
        {
            var utilizador = await _utilizadorRepository.MostrarPorId(id);
            if (utilizador == null)
            {
                return false;
            }
            return await _utilizadorRepository.Apagar(utilizador);
        }

        public async Task<bool> AtivarUtilizador(int id)
        {
            var utilizador = await _utilizadorRepository.MostrarPorId(id);
            if (utilizador == null)
            {
                return false;
            }
            utilizador.EstadoDoUtilizador = true;
            await _emailService.SendEmailAsync(utilizador.Email, "Activação de conta", "A sua conta está activa");
            return await _utilizadorRepository.Atualizar(utilizador);
        }

        public async Task<bool> AtualizarDadosDoUtilizador(int id, UtilizadorAtualizarDTO utilizadorAtualizarDTO)
        {
            var utilizador = await _utilizadorRepository.MostrarPorId(id);

            if (utilizador == null)
            {
                return false;
            }
            utilizador.NomeCompleto = utilizadorAtualizarDTO.NomeCompleto;
            utilizador.Email = utilizadorAtualizarDTO.Email;
            utilizador.BI = utilizadorAtualizarDTO.Bi;
            utilizador.FotoPath = utilizadorAtualizarDTO.FotoPath;
            utilizador.Phone = utilizadorAtualizarDTO.Phone;
            utilizador.Password = utilizadorAtualizarDTO.Password;
            return await _utilizadorRepository.Atualizar(utilizador);
        }

        public async Task<bool> Bloquear_e_DesbloquearConta(int id)
        {
            var utilizador = await _utilizadorRepository.MostrarPorId(id);
            if (utilizador == null)
            {
                return false;
            }
            utilizador.EstadoDaConta = !utilizador.EstadoDaConta;
            string subject = "Conta Bloqueada";
            string locked = "A sua conta foi bloqueada...";
            string unlock = "A sua conta foi desbloqueada...";
            if (utilizador.EstadoDaConta)
            {
              await  _emailService.SendEmailAsync(utilizador.Email, subject, unlock);
            }
            else
            {
              await  _emailService.SendEmailAsync(utilizador.Email, subject,locked);
            }
             
            return await _utilizadorRepository.Atualizar(utilizador);
           
        }

        public async Task<List<Utilizador>> ListarTodosUsuarios()
        {
            return await _utilizadorRepository.Listar();
        }

        public async Task<Utilizador> MostrarUtilizadorPorId(int id)
        {
            return await _utilizadorRepository.MostrarPorId(id);
        }
        // Método para enviar email ao administrador
        private async Task EnviarEmailParaAdministrador(Utilizador utilizador)
        {
            string subject = "Novo Registo de Utilizador";
            string body = $"Um novo cliente registou-se na aplicação:\n\n" +
                          $"Nome Completo: {utilizador.NomeCompleto}\n" +
                          $"Email: {utilizador.Email}\n\n" +
                          "Por favor, ative a conta deste utilizador.";
            await _emailService.SendEmailAsync(_adminEmail, subject, body);
        }

        // Método para enviar email
        private async Task EnviarEmail(string to, string subject, string body)
        {
            await _emailService.SendEmailAsync(to, subject, body);
        }


        public async Task<Utilizador?> Login(string username, string password)
        {
            var user = await _utilizadorRepository.MostrarPorUsername(username);

            if (user == null || user.Password != password)
            {
                return null;
            }

            return user;
        }
        public async Task<Utilizador> MostrarPorUsername(string username)
        {
            return await _utilizadorRepository.MostrarPorUsername(username);
        }

        public async Task<bool> AtualizarCredencias(int id, PasswordAtualizarDTO passwordDTO)
        {
            var utilizador = await _utilizadorRepository.MostrarPorId(id);
            if (utilizador == null)
            {
                return false;
            }
            utilizador.UserName = passwordDTO.UserName;
            utilizador.Password = passwordDTO.Password;
            utilizador.EstadoDaConta = true; 

            return await _utilizadorRepository.Atualizar(utilizador);
        }
    }
}
