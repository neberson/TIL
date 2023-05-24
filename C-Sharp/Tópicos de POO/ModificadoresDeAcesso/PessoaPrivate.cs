using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModificadoresDeAcesso
{
    public class PessoaPrivate
    {
        private string nome;
        private int idade;
        private string genero;

        public void SetNome(string novoNome)
        {
            nome = novoNome;
        }

        public string GetNome()
        {
            return nome;
        }

        public void SetIdade(int novaIdade)
        {
            idade = novaIdade;
        }

        public int GetIdade()
        {
            return idade;
        }

        public void SetGenero(string novoGenero)
        {
            genero = novoGenero;
        }

        public string GetGenero()
        {
            return genero;
        }

        public void Identificar()
        {
            Console.WriteLine($"Olá, sou o {nome}, tenho {idade} anos e sou do sexo {genero}.");
        }
    }
}
