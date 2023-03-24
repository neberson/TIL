namespace Construtores
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa1 = new Pessoa();

            pessoa1.Nome = "Paulo";
            pessoa1.Idade = 45;
            pessoa1.Genero = "Masculino";
            pessoa1.Identificar();

            Pessoa pessoa2 = new Pessoa("Paulo", 45, "Masculino");
            pessoa2.Identificar();

            ContaBancaria conta = new ContaBancaria("João Batista");
            conta.Depositar(100);
            conta.Sacar(50);
            conta.MostrarDetalhes();
        }
    }
}