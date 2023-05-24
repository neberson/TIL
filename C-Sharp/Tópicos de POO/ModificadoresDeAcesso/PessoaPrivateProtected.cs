using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModificadoresDeAcesso
{
    public class PessoaPrivateProtected
    {
        private protected string nome;
        private protected int idade;
        private protected string genero;

        public void Identificar()
        {
            Console.WriteLine($"Olá, sou o {nome}, tenho {idade} anos e sou do sexo {genero}.");
        }
    }
}
