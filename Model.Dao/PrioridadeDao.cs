using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    class PrioridadeDao : Obrigatorio<Prioridade>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public PrioridadeDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }
        public void create(Prioridade objPrioridade)
        {
            string create = "insert into prioridade values('" + objPrioridade.PrioridadeDescricao + "')";

            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objPrioridade.Estado = 1000;
                
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB(); ;
            }
        }

        public void delete(Prioridade objPrioridade)
        {
            string delete = "delete from categegoria where idPrioridade='" + objPrioridade.IdPrioridade + "'";

            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                objPrioridade.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(Prioridade obj)
        {
            throw new NotImplementedException();
        }

        public List<Prioridade> findAll()
        {
            throw new NotImplementedException();
        }

        public void update(Prioridade obj)
        {
            throw new NotImplementedException();
        }
    }
}
