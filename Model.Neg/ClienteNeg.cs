using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Neg
{
    public class ClienteNeg
    {
        private ClienteDao objClienteDao;
        public ClienteNeg()
        {
            objClienteDao = new Dao.ClienteDao();
        }

        public void create(Cliente objCliente)
        {
            bool verificacao = true;

            string pessoa = objCliente.Pessoa;
                if(pessoa == null)
            {
                objCliente.Estado = 20;
            }
            else
            {
                pessoa = objCliente.Pessoa.Trim();
                verificacao = pessoa.Length > 0 && pessoa.Length <= 30;
                    if(!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }
            }
            string email = objCliente.Email;
            if (email == null)
            {
                objCliente.Estado = 20;
            }
            else
            {
                email = objCliente.Email.Trim();
                verificacao = email.Length > 0 && email.Length <= 30;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }
            }

            string cnpj = objCliente.Cnpj;
            if (cnpj == null)
            {
                objCliente.Estado = 20;
            }
            else
            {
                cnpj = objCliente.Cnpj.Trim();
                verificacao = cnpj.Length > 10 && cnpj.Length <= 15;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }
            }

            string razaoSocial = objCliente.RazaoSocial;
            if (razaoSocial == null)
            {
                objCliente.Estado = 20;
            }
            else
            {
                razaoSocial = objCliente.RazaoSocial.Trim();
                verificacao = razaoSocial.Length > 0 && razaoSocial.Length <= 30;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }
            }

            string telefone = objCliente.Telefone;
            if (telefone == null)
            {
                objCliente.Estado = 20;
            }
            else
            {
                telefone = objCliente.Telefone.Trim();
                verificacao = telefone.Length > 0 && telefone.Length <= 30;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }
            }

            string endereco = objCliente.Endereco;
            if (endereco == null)
            {
                objCliente.Estado = 20;
            }
            else
            {
                endereco = objCliente.Endereco.Trim();
                verificacao = endereco.Length > 0 && endereco.Length <= 30;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }
            }

            string cidade = objCliente.Cidade;
            if (cidade == null)
            {
                objCliente.Estado = 20;
            }
            else
            {
                cidade = objCliente.Endereco.Trim();
                verificacao = cidade.Length > 0 && cidade.Length <= 30;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }
            }

            //Cliente objClienteAux = new Cliente();
            //objClienteAux.IdCliente = objCliente.IdCliente;
            //verificacao = !objClienteDao.find(objClienteAux);
             //   if(!verificacao)
           // {
            //    objCliente.Estado = 4;
             //   return;
            //}
            objCliente.Estado = 99;
            objClienteDao.create(objCliente);
            return;
         }
        public List<Cliente> findAll()
        {
            return objClienteDao.findAll();
        }
        public bool find(Cliente objCliente)
        {
            return objClienteDao.find(objCliente);
        }
    }
}
