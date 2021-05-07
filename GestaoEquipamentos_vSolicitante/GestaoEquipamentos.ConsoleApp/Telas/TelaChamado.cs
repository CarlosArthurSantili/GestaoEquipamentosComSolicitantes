using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaChamado : TelaBase
    {
        private ControladorEquipamento controladorEquipamento;
        private ControladorChamado controladorChamado;
        private ControladorSolicitante controladorSolicitante;

        public TelaChamado(ControladorChamado cc, ControladorEquipamento ce, ControladorSolicitante cs) : base("Controle de Chamados")
        {
            controladorEquipamento = ce;
            controladorChamado = cc;
            controladorSolicitante = cs;
        }

        public override void Excluir()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            try
            {
                Console.Write("Digite o id do chamado que deseja excluir: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controladorChamado.VerificaIdExistente(idSelecionado))
                {
                    bool conseguiuExcluir = controladorChamado.ExcluirChamado(idSelecionado);
                    if (conseguiuExcluir)
                    {
                        Console.WriteLine("Chamado excluído com sucesso");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Erro ao excluir o chamado");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Não existe id chamado com esse valor de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }

                
            }
            catch
            {
                Console.WriteLine("Valor digitado de id chamado não é um 'int', tente novamente");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public override void Editar()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();
            try
            {
                Console.Write("Digite o id do chamado que deseja editar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controladorChamado.VerificaIdExistente(idSelecionado))
                    Registrar(idSelecionado);
                else
                {
                    Console.WriteLine("Não existe id chamado com esse valor de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch 
            {
                Console.WriteLine("Valor digitado de id chamado não é um 'int', tente novamente");
                Console.ReadLine();
                Console.Clear();
            }
}

        public override void Visualizar()
        {
            Console.Clear();
            Chamado[] chamados = controladorChamado.SelecionarTodosChamados();

            if (chamados.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum chamado registrado!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Visualização de Chamados");

                string configuraColunasTabela = "{0,-4} | {1,-8} | {2,-8} | {3,-8} | {4,-8}";
                Console.ForegroundColor = ConsoleColor.Red;

                
                Console.WriteLine(configuraColunasTabela, "Id", "Solicitante", "Equipamento", "Título", "Dias em Aberto");

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                foreach (Chamado chamado in chamados)
                {
                    Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25}",
                        chamado.id, chamado.solicitante.nome, chamado.equipamento.nome, chamado.titulo, chamado.DiasEmAberto);
                }

            }
        }

        public void VisualizarEquipamentos()
        {
            Console.Clear();

            Console.WriteLine("Visualização Equipamentos");
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

            if (equipamentos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum equipamento cadastrado!");
                Console.ResetColor();
            }
        }

        public void VisualizarSolicitantes()
        {
            Console.Clear();

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

        public override void Registrar(int idChamadoSelecionado)
        {
            Console.Clear();
            string resultadoValidacao = "";
            if (controladorEquipamento.SelecionarTodosEquipamentos().Length == 0)
            {
                Console.WriteLine("Não é possível cadastrar chamados sem equipamentos cadastrados");
                Console.ReadLine();
                Console.Clear();
                resultadoValidacao = "QTD_ID_EQUIPAMENTO_INVALIDO";
            }
            else if (controladorSolicitante.SelecionarTodosSolicitantes().Length == 0)
            {
                Console.WriteLine("Não é possível cadastrar chamados sem solicitantes cadastrados");
                Console.ReadLine();
                Console.Clear();
                resultadoValidacao = "QTD_ID_SOLICITANTE_INVALIDO";
            }
            else
            {
                do
                {
                    VisualizarSolicitantes();
                    try
                    {
                        Console.Write("Digite o id do solicitante para manutenção: ");
                        int idSolicitanteChamado = Convert.ToInt32(Console.ReadLine());
                        if (controladorSolicitante.VerificaIdExistente(idSolicitanteChamado))
                        {
                            try
                            {
                                VisualizarEquipamentos();
                                Console.Write("Digite o id do equipamento para manutenção: ");
                                int idEquipamentoChamado = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                if (controladorEquipamento.VerificaIdExistente(idEquipamentoChamado))
                                {
                                    Console.Write("Digite o titulo do chamado: ");
                                    string titulo = Console.ReadLine();

                                    Console.Write("Digite a descricao do chamado: ");
                                    string descricao = Console.ReadLine();
                                    try
                                    {
                                        Console.Write("Digite a data de abertura do chamado: ");
                                        DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

                                        resultadoValidacao = controladorChamado.RegistrarChamado(idChamadoSelecionado, idSolicitanteChamado, idEquipamentoChamado, titulo, descricao, dataAbertura);

                                        if (resultadoValidacao != "CHAMADO_VALIDO")
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
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Valor de data de abertura digitado não é um 'DateTime', tente novamente");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Valor de id equipamento digitado não está cadastrado, tente novamente");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Valor de id equipamento digitado não é um 'int', tente novamente");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor de id solicitante digitado não está cadastrado, tente novamente");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    catch 
                    {
                        Console.WriteLine("Valor de id solicitante digitado não é um 'int', tente novamente");
                        Console.ReadLine();
                        Console.Clear();
                    }
                } while (resultadoValidacao != "CHAMADO_VALIDO");
            }
        }       

        public override string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir novo chamado");
            Console.WriteLine("Digite 2 para visualizar chamados");
            Console.WriteLine("Digite 3 para editar um chamado");
            Console.WriteLine("Digite 4 para excluir um chamado");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
