using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorSolicitante : ControladorBase
    {
        public ControladorSolicitante(int capacidadeRegistros) : base(capacidadeRegistros)
        {
        }

        public string RegistrarSolicitante(int id, string nome, string email, string telefone)
        {
            Solicitante solicitante;
            int posicao = 0;

            if (id == 0)
            {
                solicitante = new Solicitante();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                Solicitante solicitanteSubstituido = SelecionarSolicitantePorId(id);
                posicao = ObterPosicaoOcupada(solicitanteSubstituido);
                solicitante = (Solicitante)registros[posicao];
            }

            solicitante.nome = nome;
            solicitante.email = email;
            solicitante.telefone = telefone;

            string resultadoValidacao = solicitante.Validar();

            if (resultadoValidacao == "EQUIPAMENTO_VALIDO")
                registros[posicao] = solicitante;

            return resultadoValidacao;
        }

        public bool ExcluirSolicitante(int idSelecionado)
        {
            return ExcluirRegistro(new Solicitante(idSelecionado));
        }

        public Solicitante SelecionarSolicitantePorId(int id)
        {
            return (Solicitante)SelecionarRegistro(new Solicitante(id));
        }

        public Solicitante[] SelecionarTodosSolicitantes()
        {
            Solicitante[] solicitantesAux = new Solicitante[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), solicitantesAux, solicitantesAux.Length);

            return solicitantesAux;
        }

        public bool VerificaIdExistente(int idCheck)
        {
            foreach (Solicitante s in SelecionarTodosSolicitantes())
            {
                if (s.id == idCheck)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
