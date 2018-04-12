using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Cliente
    {
        private long idCliente;
        private string pessoa;
        private string email;
        private string telefone;
        private string cnpj;
        private string razaoSocial;
        private string apelido;
        private int estado;
        private string endereco;
        private string cidade;

        public long IdCliente { get => idCliente; set => idCliente = value; }
        public string Pessoa { get => pessoa; set => pessoa = value; }
        public string Email { get => email; set => email = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Cnpj { get => cnpj; set => cnpj = value; }
        public string RazaoSocial { get => razaoSocial; set => razaoSocial = value; }
        public string Apelido { get => apelido; set => apelido = value; }
        public int Estado { get => estado; set => estado = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Cidade { get => cidade; set => cidade = value; }

        public Cliente()
        {

        }
        public Cliente(long idCliente)
        {
            this.idCliente = idCliente;
        }
        public Cliente(long idCliente, string pessoa, string email, string telefone, string cnpj, string razaoSocial, string apelido, string endereco, string cidade)
        {
            this.idCliente = idCliente;
            this.Pessoa = pessoa;
            this.Email = email;
            this.Telefone = telefone;
            this.Cnpj = cnpj;
            this.RazaoSocial = razaoSocial;
            this.Apelido = apelido;
            this.Endereco = endereco;
            this.Cidade = cidade;

        }
    }
}
