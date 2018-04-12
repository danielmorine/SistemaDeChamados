using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Prioridade
    {
        private string idPrioridade;
        private string prioridadeDescricao;
        private int estado;

        public string IdPrioridade { get => idPrioridade; set => idPrioridade = value; }
        public string PrioridadeDescricao { get => prioridadeDescricao; set => prioridadeDescricao = value; }
        public int Estado { get => estado; set => estado = value; }

        public Prioridade()
        {

        }
        public Prioridade(string idPrioridade)
        {

        }
        public Prioridade(string idPrioridade, string prioridadeDescricao)
        {
            this.idPrioridade = idPrioridade;
            this.PrioridadeDescricao = prioridadeDescricao;
        }
        
    }
}
