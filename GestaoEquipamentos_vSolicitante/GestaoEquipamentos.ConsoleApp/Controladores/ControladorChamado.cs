using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorChamado : ControladorBase
    {
        private ControladorEquipamento controladorEquipamento;
        private ControladorSolicitante controladorSolicitante;

        public ControladorChamado(int capacidadeRegistros, ControladorEquipamento ce, ControladorSolicitante cs) : base(capacidadeRegistros)
        {
            controladorEquipamento = ce;
            controladorSolicitante = cs;
        }

        public string RegistrarChamado(int idChamado, int idSolicitanteChamado,int idEquipamentoChamado,
            string titulo, string descricao, DateTime dataAbertura)
        {
            Chamado novoChamado;
            int posicao;
            string resultadoValidacao = "";

            if (idChamado == 0)
            {
                novoChamado = new Chamado();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                Chamado chamadoSubstituido = SelecionarChamadoPorId(idChamado);
                posicao = ObterPosicaoOcupada(chamadoSubstituido);
                novoChamado = (Chamado)registros[posicao];
            }

            novoChamado.solicitante = controladorSolicitante.SelecionarSolicitantePorId(idSolicitanteChamado);
            novoChamado.equipamento = controladorEquipamento.SelecionarEquipamentoPorId(idEquipamentoChamado);
            novoChamado.titulo = titulo;
            novoChamado.descricao = descricao;
            novoChamado.dataAbertura = dataAbertura;
            resultadoValidacao = novoChamado.Validar();
            if (resultadoValidacao == "CHAMADO_VALIDO")
                registros[posicao] = novoChamado;

            return resultadoValidacao;
        }

        public bool ExcluirChamado(int idSelecionado)
        {
            return ExcluirRegistro(new Chamado(idSelecionado));
        }

        public Chamado SelecionarChamadoPorId(int id)
        {
            return (Chamado)SelecionarRegistro(new Chamado(id));
        }

        public Chamado[] SelecionarTodosChamados()
        {
            Chamado[] chamadosAux = new Chamado[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), chamadosAux, chamadosAux.Length);

            return chamadosAux;
        }

        public bool VerificaIdExistente(int idCheck)
        {
            foreach (Chamado c in SelecionarTodosChamados())
            {
                if (c.id == idCheck)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
