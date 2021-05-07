using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp.Dominio
{
    public class Solicitante : EntidadeBase
    {
        public string nome;
        public string email;
        public string telefone;

        public Solicitante()
        {
            id = GeradorId.GerarIdSolicitante();
        }

        public Solicitante(int id)
        {
            this.id = id;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo Nome é obrigatório \n";

            if (nome.Length < 6)
                resultadoValidacao += "O campo Nome não pode ter menos de 6 letras \n";

            if (string.IsNullOrEmpty(email))
                resultadoValidacao += "O campo Email é obrigatório \n";

            if (string.IsNullOrEmpty(telefone))
                resultadoValidacao += "O campo Telefone é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EQUIPAMENTO_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Solicitante s = (Solicitante)obj;

            if (s != null && s.id == this.id)
                return true;

            return false;
        }
    }
}
