namespace Estudo_Classes;
partial class Program
{
    class Pessoa
    {
        //definição dos campos/atributos da classe
        public string nome;
        public int idade;
        public string genero;

        //métodos refletem o comportamento e ações da classe
        public void Identificar()
        {
            System.Console.WriteLine($"Olá, sou o {nome} tenho {idade} e sou do sexo {genero}");
        } 
    }
}