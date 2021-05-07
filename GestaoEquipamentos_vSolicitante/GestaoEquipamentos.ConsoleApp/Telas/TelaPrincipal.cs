using GestaoEquipamentos.ConsoleApp.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaPrincipal
    {
        private readonly ControladorEquipamento controladorEquipamento;
        private readonly ControladorChamado controladorChamado;
        private readonly ControladorSolicitante controladorSolicitante;

        public TelaPrincipal(ControladorEquipamento ce, ControladorChamado cc, ControladorSolicitante cs)
        {
            this.controladorEquipamento = ce;
            this.controladorChamado = cc;
            this.controladorSolicitante = cs;
        }

        public TelaBase ObterTela()
        {
            string opcao;
            TelaBase telaSelecionada = null;

            do
            {
                Console.Clear();
                Console.WriteLine("Digite 1 para o Controle de Equipamentos");
                Console.WriteLine("Digite 2 para o Controle de Chamados");
                Console.WriteLine("Digite 3 para o Controle de Solicitantes");

                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                {
                    telaSelecionada = null;
                    return telaSelecionada;
                }
                else if (opcao == "1")
                {
                    telaSelecionada = new TelaEquipamento(controladorEquipamento);
                    return telaSelecionada;
                }
                else if (opcao == "2")
                {
                    telaSelecionada = new TelaChamado(controladorChamado, controladorEquipamento, controladorSolicitante);
                    return telaSelecionada;
                }
                else if (opcao == "3")
                {
                    telaSelecionada = new TelaSolicitante(controladorSolicitante);
                    return telaSelecionada;
                }
                else
                {
                    Console.WriteLine("Opcao inválida, tente novamente");
                    Console.ReadLine();
                }
            } while(true);
        }
    }
}
