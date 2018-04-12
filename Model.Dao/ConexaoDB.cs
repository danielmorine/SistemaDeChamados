using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    class ConexaoDB
    {
        private static ConexaoDB objConexaoDB = null;
        private SqlConnection con;

        private ConexaoDB()
        {
            con = new SqlConnection("Data Source=DESKTOP-RNV9ESI; Initial Catalog=chamados; Integrated Security=True");
        }
        public static ConexaoDB saberEstado()
        {
            if(objConexaoDB == null)
            {
                objConexaoDB = new ConexaoDB();
            }
            return objConexaoDB;
        }

        public SqlConnection getCon()
        {
            return con;
        }
        
        public void CloseDB()
        {
            objConexaoDB = null;
        }
    }
}
