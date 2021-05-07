using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp.Dominio
{
    public class EntidadeBase
    {
        public int id;

        public virtual string Validar() 
        {
            return "";
        }

        
    }
}
