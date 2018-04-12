using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Prioridade
    {
        private long idPrioridade;
        private string prioridadeDescricao;
        private int estado;

        public long IdPrioridade { get => idPrioridade; set => idPrioridade = value; }
        public string PrioridadeDescricao { get => prioridadeDescricao; set => prioridadeDescricao = value; }
        public int Estado { get => estado; set => estado = value; }

        public Prioridade()
        {

        }
        public Prioridade(long idPrioridade)
        {

        }
        public Prioridade(long idPrioridade, string prioridadeDescricao)
        {
            this.idPrioridade = idPrioridade;
            this.PrioridadeDescricao = prioridadeDescricao;
        }
        
    }
}
