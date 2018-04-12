using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
   public class Categoria
    {
        private long idCategoria;
        private string nome;
        private int estado;

        public long IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Estado { get => estado; set => estado = value; }

        public Categoria()
        {

        }
        public Categoria(long idCategoria, string nome)
        {
            this.idCategoria = idCategoria;
            this.Nome = nome;
        }
        public Categoria(long idCategoria)
        {
            this.idCategoria = idCategoria;
        }
    }
}
