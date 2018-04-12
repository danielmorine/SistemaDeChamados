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

        public bool find(Prioridade objPrioridade)
        {
            bool TemReginstros;
            string find="select * from prioridade where IdPrioridade='" + objPrioridade.IdPrioridade + "'";

            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                reader = comando.ExecuteReader();
                TemReginstros = reader.Read();
                    if(TemReginstros)
                {
                    objPrioridade.PrioridadeDescricao = reader[1].ToString();

                    objPrioridade.Estado = 99;
                } else
                {
                    objPrioridade.Estado = 1;
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
            return TemReginstros;
        }
 
        public List<Prioridade> findAll()
        {
            List<Prioridade> listaPrioridades = new List<Prioridade>();
            string find = "select * from prioridade";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while(reader.Read())
                {
                    Prioridade objPrioridade = new Prioridade();
                    objPrioridade.IdPrioridade = Convert.ToInt64(reader[0].ToString());
                    objPrioridade.PrioridadeDescricao = reader[1].ToString();

                        listaPrioridades.Add(objPrioridade);
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

            return listaPrioridades;
        }

        public void update(Prioridade objPrioridade)
        {
            string update = "update prioridade set prioridadeDescircao='" + objPrioridade.PrioridadeDescricao + " ' where idPrioridade='" + objPrioridade.IdPrioridade +  "'' " ;
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                objPrioridade.Estado = 1;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
    }
}
