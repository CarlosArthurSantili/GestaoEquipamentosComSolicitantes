using System;
using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Telas;

namespace GestaoEquipamentos.ConsoleApp
{
    class Program
    {
        #region Especificação 
        /** Requisito 1.1 [OK] [12,5 % Concluído]
         * Como funcionário, Junior quer ter a possibilidade 
         * de registrar equipamentos
    
            Critérios:
        
             •  Deve ter um nome com no mínimo 6 caracteres;  
             •  Deve ter um preço de aquisição;  
             •  Deve ter um número de série;  
             •  Deve ter uma data de fabricação;  
             •  Deve ter uma fabricante; 
         */

        /** Requisito 1.2 [OK] [25% Concluído]
         * Como funcionário, Junior quer ter a possibilidade 
         * de visualizar todos os equipamentos registrados em seu inventário
    
            Critérios:
        
             •  Deve mostrar o nome;  
             •  Deve mostrar o preço de aquisição;  
             •  Deve mostrar o número de série;  
             •  Deve mostrar a data de fabricação;  
             •  Deve mostrar o fabricante; 
         */

        /** Requisito 1.3 [OK] [37,5% Concluído]
         * Como funcionário, Junior quer ter a possibilidade 
         * de editar um equipamento, sendo que ele possa editar todos os campos
    
            Critérios:
        
             •  Deve ter os mesmos critérios que o Requisito 1.1
         */

        /** Requisito 1.4 [OK] [50% Concluído]
         * 
         * Como funcionário, Junior quer ter a possibilidade 
         * de excluir um equipamento que esteja registrado.    
         * 
         *    •   A lista de equipamentos deve ser atualizada
         */

        /** Requisito 2.1 [OK] [62,5% Concluído]
         * 
         * Como funcionário, Junior quer ter a possibilidade 
         * de registrar os chamados de manutenções que são efetuadas nos equipamentos registrados    
         * 
                 •  Deve ter a título do chamado;  
                 •  Deve ter a descrição do chamado;  
                 •  Deve ter um equipamento;  
                 •  Deve ter uma data de abertura;   
         */

        /** Requisito 2.2 [OK] [75% Concluído]
        * 
        * Como funcionário, Junior quer ter a possibilidade de
        * visualizar todos os chamados registrados para controle.   
        * 
                •  Deve ter o id do chamado;  
                •  Deve ter a título do chamado;  
                •  Deve ter a descrição do chamado;  
                •  Deve ter um equipamento;  
                •  Deve ter uma data de abertura;   
        */

        /** Requisito 2.3 [OK] [87,5% Concluído]
        * 
        * Como funcionário, Junior quer ter a possibilidade de
        * editar um chamado que esteja registrado, sendo que ele possa editar todos os campos   
        * 
                •  Deve ter os mesmos critérios que o Requisito 2.1  
        */

        /** Requisito 2.4 [OK] [100% Concluído]
        * 
        * Como funcionário, Junior quer ter a possibilidade
        * de excluir um chamado
        * 
                •  A lista de chamados deve ser atualizada 
        */
        #endregion

        const int CAPACIDADE_REGISTROS = 100;

        static void Main(string[] args)
        {
            ControladorEquipamento controladorEquipamento = new ControladorEquipamento(CAPACIDADE_REGISTROS);

            ControladorSolicitante controladorSolicitante = new ControladorSolicitante(CAPACIDADE_REGISTROS);

            ControladorChamado controladorChamado = new ControladorChamado(CAPACIDADE_REGISTROS, controladorEquipamento, controladorSolicitante);

            TelaPrincipal telaPrincipal = new TelaPrincipal(controladorEquipamento, controladorChamado, controladorSolicitante);

            Console.Clear();
            
            while (true)
            {
                TelaBase telaSelecionada = telaPrincipal.ObterTela();
                if (telaSelecionada == null)
                    break;

                Console.Clear();
                Console.WriteLine(telaSelecionada.Titulo);
                Console.WriteLine();
                string opcao = telaSelecionada.ObterOpcao();

                Console.Clear();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (opcao == "1")
                    telaSelecionada.Registrar(0);

                else if (opcao == "2")
                {
                    telaSelecionada.Visualizar();
                    Console.ReadLine();
                }
                else if (opcao == "3")
                    telaSelecionada.Editar();

                else if (opcao == "4")
                    telaSelecionada.Excluir();

                Console.Clear();
            }
        }        
    }
}
