using System;
using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Dominio;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    /// <summary>
    /// encarregada pela interação com usuário 
    /// (inputs, mensagens na tela)
    /// 
    /// VIEW == VISUALIZAÇÃO
    /// </summary>
    public class TelaEquipamento : TelaBase
    {
        //atributo
        private readonly ControladorEquipamento controladorEquipamento;

        public TelaEquipamento(ControladorEquipamento controlador) : base("Controle de Equipamentos")
        {
            controladorEquipamento = controlador;
        }

        public override string ObterOpcao()
        {
            //apresenta as opções
            Console.WriteLine("Digite 1 para inserir novo equipamento");
            Console.WriteLine("Digite 2 para visualizar equipamentos");
            Console.WriteLine("Digite 3 para editar um equipamento");
            Console.WriteLine("Digite 4 para excluir um equipamento");

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
                Console.Write("Digite o número do equipamento que deseja editar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controladorEquipamento.VerificaIdExistente(idSelecionado))
                    Registrar(idSelecionado);
                else
                {
                    Console.WriteLine("Não existe id equipamento com esse valor de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch 
            {
                Console.WriteLine("Valor digitado de id equipamento não é um 'int', tente novamente");
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
                Console.Write("Digite o número do equipamento que deseja excluir: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controladorEquipamento.VerificaIdExistente(idSelecionado))
                {
                    bool conseguiuExcluir = controladorEquipamento.ExcluirEquipamento(idSelecionado);
                    if (conseguiuExcluir)
                    {
                        Console.WriteLine("Equipamento excluído com sucesso");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else 
                    {
                        Console.WriteLine("Erro ao excluir o equipamento");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Não existe id equipamento com esse valor de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }

                
            }
            catch
            {
                Console.WriteLine("Valor digitado de id equipamento não é um 'int', tente novamente");
                Console.ReadLine();
                Console.Clear();
            }

            
        }

        public override void Visualizar()
        {
            Console.Clear();

            if (controladorEquipamento.SelecionarTodosEquipamentos().Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum equipamento cadastrado!");
                Console.ResetColor();
            }
            else 
            {
                Console.WriteLine("Visualização de Equipamentos");
                string configuraColunasTabela = "{0,-10} | {1,-10} | {2,-10}";

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(configuraColunasTabela, "Id", "Nome", "Fabricante");

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                Equipamento[] equipamentos = controladorEquipamento.SelecionarTodosEquipamentos();

                for (int i = 0; i < equipamentos.Length; i++)
                {
                    Console.Write(configuraColunasTabela,
                       equipamentos[i].id, equipamentos[i].nome, equipamentos[i].fabricante);

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
                Console.Write("Digite o nome do equipamento: ");
                string nome = Console.ReadLine();

                try
                {
                    Console.Write("Digite o preço do equipamento: ");
                    double preco = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Digite o número do equipamento: ");
                    string numeroSerie = Console.ReadLine();

                    try
                    {
                        Console.Write("Digite a data de fabricação do equipamento: ");
                        DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

                        Console.Write("Digite o fabricante do equipamento: ");
                        string fabricante = Console.ReadLine();

                        resultadoValidacao = controladorEquipamento.RegistrarEquipamento(
                            id, nome, preco, numeroSerie, dataFabricacao, fabricante);
                    }
                    catch 
                    {
                        Console.WriteLine("Valor digitado não é um 'DateTime', tente novamente");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Valor digitado não possui é um 'double', tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                

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
