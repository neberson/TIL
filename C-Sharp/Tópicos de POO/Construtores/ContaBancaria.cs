using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construtores
{
    class ContaBancaria
    {
        private string _nomeDoTitular;
        private decimal _saldo;

        /*construtor da classe*/
        public ContaBancaria(string nomeDoTitular) 
        { 
            _nomeDoTitular= nomeDoTitular;
        }

        public void Depositar(decimal valor)
        {
            _saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            _saldo -= valor;
        }

        public void MostrarDetalhes()
        {
            Console.WriteLine($"{_nomeDoTitular} possui um saldo de {_saldo:C2}");
        }
    }
}
