namespace Construtores;
partial class Program
{
    class Pessoa
    {
        //definição dos campos/atributos da classe
        public string Nome;
        public int Idade;
        public string Genero;
        /*Construtor da classe Pessoa, sem parametros*/
        public Pessoa()
        {
        }

        /*Construtor da classe Pessoa, recebendo apenas um parametro*/
        public Pessoa(string nome)
        {
            Nome = nome;
        }
        /*Construtor da classe Pessoa, inferindo parametros*/
        public Pessoa(string nome, int idade, string genero)
        {
            Nome = nome;
            Idade = idade; 
            Genero = genero;
        }

        //métodos refletem o comportamento e ações da classe
        public void Identificar()
        {
            System.Console.WriteLine($"Olá, sou o {Nome} tenho {Idade} e sou do sexo {Genero}");
        } 
    }
}