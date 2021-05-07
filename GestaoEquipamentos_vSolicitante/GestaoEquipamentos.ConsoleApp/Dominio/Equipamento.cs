using System;

namespace GestaoEquipamentos.ConsoleApp.Dominio
{
    /// <summary>
    /// Centraliza as regras de negócio de um requisito
    /// </summary>
    public class Equipamento : EntidadeBase
    {
        public string nome;
        public double preco;
        public string numeroSerie;
        public DateTime dataFabricacao;
        public string fabricante;
        
        public Equipamento()
        {
            id = GeradorId.GerarIdEquipamento();
        }

        public Equipamento(int id)
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

            if (dataFabricacao > DateTime.Now)
                resultadoValidacao += "O campo Data de Fabricação não pode ser nmo futuro \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EQUIPAMENTO_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Equipamento e = (Equipamento)obj;

            if (e != null && e.id == this.id)
                return true;

            return false;
        }
    }
}