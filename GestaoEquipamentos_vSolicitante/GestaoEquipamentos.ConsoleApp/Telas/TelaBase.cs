using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaBase
    {
        private readonly string tituloTela;

        public TelaBase(string tituloTela)
        {
            this.tituloTela = tituloTela;
        }

        public string Titulo { get { return tituloTela; } }

        public virtual string ObterOpcao()
        {
            return "";
        }

        public virtual void Editar()
        {

        }

        public virtual void Excluir()
        {

        }

        public virtual void Visualizar()
        {

        }

        public virtual void Registrar(int id)
        {

        }

        protected void ConfigurarTela(string subtitulo) { }

        protected void ApresentarMensagem(string mensagem) { }
    }
}
