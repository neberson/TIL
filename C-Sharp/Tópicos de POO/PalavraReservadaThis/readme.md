Palavra Reservada "this"
==========
A palavra reservada "this" é utilizada em C# para referenciar a instância atual de um objeto. Ela é uma forma de se referir ao próprio objeto e é usada em uma classe para se referir aos seus próprios membros.

A palavra "this" é útil quando precisamos distinguir variáveis de classe de variáveis de instância. Quando temos uma variável de escopo com o mesmo nome de uma variável de instância, o compilador C# não sabe a qual delas estamos nos referindo. Para resolver esse problema, utilizamos a palavra "this" para nos referirmos à variável de instância.

Uso
-----
Suponha que você tenha uma classe "Pessoa" com um atributo "Nome". Você pode se referir a esse atributo dentro da própria classe utilizando a palavra "this".

- Exemplo de uma classe Pessoa:

```csharp
    class Pessoa
    {
        //definição dos campos/atributos da classe
        public string Nome;
  
        /*Construtor base da classe Pessoa*/
        public Pessoa(string nome)
        {
            this.Nome = nome;
        }
    }
```

A palavra "this" pode ser utilizada também para referenciar métodos da classe. Suponha que essa classe "Pessoa" tenha os atributos "Idade" e "Genero" e que seja obrigatório informar apenas o nome ao instanciar um objeto da classe. Para isso, podemos criar um construtor base com todos os atributos e uma sobrecarga apenas com o atributo nome. Essa sobrecarga pode chamar o construtor base passando valores padrões, e isso pode ser feito utilizando a palavra "this".

- Exemplo da classe Pessoa utilizando a palavra "this" para sobrecarga de construtor:

```csharp
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
``` 

Observe que a utilização da palavra "this" para chamar o construtor base na sobrecarga de construtor permite que tenhamos uma forma mais prática de inicializar as variáveis de instância da classe.

Importante: a palavra "this" deve ser utilizada com moderação para evitar uma sintaxe excessivamente complexa. Em alguns casos, o uso excessivo de "this" pode tornar o código confuso e difícil de ler. Portanto, é importante avaliar se é realmente necessário utilizá-la em determinado trecho do código.


Referências
-----
<p>Udemy Macoratti:  https://www.udemy.com/course/c-aplicando-principios-solid-na-pratica/learn/lecture/19240560#overview</p>
<p>Livro: André Carlucci, Carlos dos Santos, Claudenir C.Andrade, Rafael Almeida Santos. C# PARA INICIANTES desenvolvendo seu primeiro progama. 2021 Versão Digital</p>
