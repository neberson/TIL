using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModificadoresDeAcesso
{
    public class PessoaPublic
    {
        public string nome;
        public int idade;
        public string genero;

        public void Identificar()
        {
            Console.WriteLine($"Olá, sou o {nome}, tenho {idade} anos e sou do sexo {genero}.");
        }
    }
}
