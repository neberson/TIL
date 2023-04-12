namespace PalavraReservadaThis
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //Exemplo utilizando o construtor base
            Pessoa pessoa1 = new Pessoa("Lorraine");

            pessoa1.Idade = 32;
            pessoa1.Genero = "Feminino";
            pessoa1.Identificar();

            //Exemplo utilizando a sobrecarga do construtor com a palabra reservada THIS
            Pessoa pessoa2 = new Pessoa("Davi", 20, "Masculino");
            pessoa2.Identificar();
        }
    }
}