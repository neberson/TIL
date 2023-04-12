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
        public Pessoa(string nome, int idade, string genero) 
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Genero = genero;
        }

        /*Sobrecarga do construtor da classe Pessoa utilizando a palavra this para atribuir valor através do construtor base*/
        public Pessoa(string nome) : this(nome, 0, "Indefinido") { }

        //métodos refletem o comportamento e ações da classe
        public void Identificar()
        {
            System.Console.WriteLine($"Olá, sou o {Nome} tenho {Idade} e sou do sexo {Genero}");
        } 
    }
}