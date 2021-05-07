using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    class TelaSolicitante : TelaBase
    {
        //atributo
        private readonly ControladorSolicitante controladorSolicitante;

        public TelaSolicitante(ControladorSolicitante controlador) : base("Controle de Solicitantes")
        {
            controladorSolicitante = controlador;
        }

        public override string ObterOpcao()
        {
            //apresenta as opções
            Console.WriteLine("Digite 1 para inserir novo solicitante");
            Console.WriteLine("Digite 2 para visualizar solicitantes");
            Console.WriteLine("Digite 3 para editar um solicitante");
            Console.WriteLine("Digite 4 para excluir um solicitante");

            Console.WriteLine("Digite S para sair");

            //solicita qual opção
            string opcao = Console.ReadLine();

            return opcao;
        }

        public override void Editar()
        {
            //visualiza os equipamentos
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual equipamento atualizar
            try
            {
                Console.Write("Digite o id do solicitante que deseja editar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controladorSolicitante.VerificaIdExistente(idSelecionado))
                    Registrar(idSelecionado);
                else
                {
                    Console.WriteLine("Não existe id solicitante com esse valor de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch
            {
                Console.WriteLine("Valor digitado de id solicitante não é um 'int', tente novamente");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public override void Excluir()
        {
            //visualização dos equipamentos
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual equipamento excluir
            try
            {
                Console.Write("Digite o id do solicitante que deseja excluir: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controladorSolicitante.VerificaIdExistente(idSelecionado))
                {
                    bool conseguiuExcluir = controladorSolicitante.ExcluirSolicitante(idSelecionado);
                    if (conseguiuExcluir)
                    {
                        Console.WriteLine("Solicitante excluído com sucesso");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Erro ao excluir o solicitante");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Não existe id solicitante com esse valor de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch
            {
                Console.WriteLine("Valor digitado de id solicitante não é um 'int', tente novamente");
                Console.ReadLine();
                Console.Clear();
            }


        }

        public override void Visualizar()
        {
            Console.Clear();

            if (controladorSolicitante.SelecionarTodosSolicitantes().Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum solicitante cadastrado!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Visualização de Solicitantes");
                string configuraColunasTabela = "{0,-10} | {1,-10} | {2,-10} | {3,-10}";

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(configuraColunasTabela, "Id", "Nome", "Email", "Telefone");

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                Solicitante[] solicitantes = controladorSolicitante.SelecionarTodosSolicitantes();

                for (int i = 0; i < solicitantes.Length; i++)
                {
                    Console.Write(configuraColunasTabela,
                       solicitantes[i].id, solicitantes[i].nome, solicitantes[i].email, solicitantes[i].telefone);

                    Console.WriteLine();
                }
            }
        }

        public override void Registrar(int id)
        {
            Console.Clear();

            string resultadoValidacao = "";

            do
            {
                Console.Write("Digite o nome do solicitante: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o email do solicitante: ");
                string email = Console.ReadLine();

                Console.Write("Digite o telefone do solicitante: ");
                string telefone = Console.ReadLine();

                resultadoValidacao = controladorSolicitante.RegistrarSolicitante(
                    id, nome, email, telefone);
                    

                if (resultadoValidacao != "EQUIPAMENTO_VALIDO")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(resultadoValidacao);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registro gravado com sucesso!");
                }

                Console.ReadLine();
                Console.Clear();
                Console.ResetColor();

            } while (resultadoValidacao != "EQUIPAMENTO_VALIDO");
        }


    }
}
