using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModificadoresDeAcesso
{
    public class PessoaProtectedInternal
    {
        protected internal string nome;
        protected internal int idade;
        protected internal string genero;

        public void Identificar()
        {
            Console.WriteLine($"Olá, sou o {nome}, tenho {idade} anos e sou do sexo {genero}.");
        }
    }
}
