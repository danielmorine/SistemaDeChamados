using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Usuario
    {
        private string idUsuario;
        private string email;
        private string senha;
        private string estado;
        private string nome;

        public string Nome { get => nome; set => nome = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Email { get => email; set => email = value; }
        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Estado { get => estado; set => estado = value; }

        public Usuario()
        {

        }
        public Usuario(string idUsuario)
        {
            this.idUsuario = idUsuario;
        }
        public Usuario(string idUsuario, string senha, string email, string nome)
        {
            this.idUsuario = idUsuario;
            this.Senha = senha;
            this.Email = email;
            this.Nome = nome;
        }
    }
}
