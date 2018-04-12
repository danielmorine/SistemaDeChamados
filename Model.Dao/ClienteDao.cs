using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClienteDao : Obrigatorio<Cliente>
    {

        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public ClienteDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Cliente objCliente)
        {
            string create = "insert into cliente values('" + objCliente.Pessoa + "','" + objCliente.Email + "','"+ objCliente.Telefone + "','" + objCliente.Cnpj + "','"+ objCliente.RazaoSocial +"','" + objCliente.Apelido + "','"+ objCliente.Endereco +"','"+ objCliente.Cidade +"')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                objCliente.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(Cliente objCliente)
        {
            string delete = "delete from cliente where idCliente='"+ objCliente.IdCliente+"'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                objCliente.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(Cliente objCliente)
        {
            bool temRegistros;
            string find = "select *from cliente where idCliente='" + objCliente.IdCliente + "' ";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                    if(temRegistros)
                {
                    objCliente.Pessoa = reader[1].ToString();
                    objCliente.Email = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.Cnpj = reader[4].ToString();
                    objCliente.RazaoSocial = reader[5].ToString();
                    objCliente.Apelido = reader[6].ToString();
                    objCliente.Endereco = reader[7].ToString();
                    objCliente.Cidade = reader[8].ToString();

                    objCliente.Estado = 99;

                }
                    else
                {
                    objCliente.Estado = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
            return temRegistros;
        }

        public List<Cliente> findAll()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string find = "select * from cliente";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                    while(reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = Convert.ToInt64(reader[0].ToString());
                    objCliente.Pessoa = reader[1].ToString();
                    objCliente.Email = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.Cnpj = reader[4].ToString();
                    objCliente.RazaoSocial = reader[5].ToString();
                    objCliente.Apelido = reader[6].ToString();
                    objCliente.Endereco = reader[7].ToString();
                    objCliente.Cidade = reader[8].ToString();

                    listaClientes.Add(objCliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
            return listaClientes;
        }

        public void update(Cliente objCliente)
        {
            string update = "update cliente set pessoa='" + objCliente.Pessoa + "',email='" +
                objCliente.Email + "',telefone='" + objCliente.Telefone + "',cnpj='" +
                objCliente.Cnpj + "',razaoSocial='" + objCliente.RazaoSocial + "',apelido='" + 
                objCliente.Apelido + "',endereco='" + objCliente.Endereco + "',cidade='" + 
                objCliente.Cidade + "'where idCliente='" + objCliente.IdCliente + "'";

            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                objCliente.Estado = 1;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
    }
}
