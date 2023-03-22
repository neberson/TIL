using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudo_Classes
{
    class ContaBancaria
    {
        public string NomeDoTitular;
        public decimal Saldo;

        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public void MostrarDetalhes()
        {
            Console.WriteLine($"{NomeDoTitular} possui um saldo de {Saldo:C2}");
        }
    }
}
