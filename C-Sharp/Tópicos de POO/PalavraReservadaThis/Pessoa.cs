namespace PalavraReservadaThis;
partial class Program
{
    class Pessoa
    {
        //definição dos campos/atributos da classe
        public string Nome;
        public int Idade;
        public string Genero;
        /*Construtor base da classe Pessoa*/
        public Pessoa(string nome)
        {
            this.Nome = nome;
        }

        /*Sobrecarga do construtor da classe Pessoa utilizando a palavra this para atribuir valor ao nome através do construtor base*/
        public Pessoa(string nome, int idade, string genero) : this(nome)
        {
            this.Idade  = idade;
            this.Genero = genero;
        }

        //métodos refletem o comportamento e ações da classe
        public void Identificar()
        {
            System.Console.WriteLine($"Olá, sou o {Nome} tenho {Idade} e sou do sexo {Genero}");
        } 
    }
}