using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class TipoContrato
    {
        private string idTipoContrato;
        private string tipoContratoNome;
        private string descricao;

        public string IdTipoContrato { get => idTipoContrato; set => idTipoContrato = value; }
        public string TipoContratoNome { get => tipoContratoNome; set => tipoContratoNome = value; }
        public string Descricao { get => descricao; set => descricao = value; }


        public TipoContrato()
        {

        }
        public TipoContrato(string idTipoContrato)
        {
            this.IdTipoContrato = idTipoContrato;
        }
        public TipoContrato(string idTipoContrato, string tipoContratoNome, string descricao)
        {
            this.IdTipoContrato = idTipoContrato;
            this.TipoContratoNome = tipoContratoNome;
            this.Descricao = descricao;
        }
    }
}
