Construtores
==========
Além de atribuir valores à um objeto após a sua criação, temos a possibilidade de realizar essa atribuição no momento da criação/instanciação do objeto. Para que seja possível essa atribuição de valores no momento de instanciar o objeto, criamos os construtores na classe, informando quais os atributos da classe que recebem algum valor no momento da instanciação de seus objetos.

Um construtor é um método especial usado para inicializar objetos. O construtor é chamado quando um objeto de uma classe é criado usando a palavra reservada "new". Por padrão no c# as classes já contém um construtor "vazio" (que não recebe parâmetros), pelo fato de existir esse construtor padrão é possível instanciar a classe sem informar os dados no momento da criação do objeto. Para o construtor padrão, no momento da instanciação do objeto da classe, a própria linguagem de programação vai inferir valores padrões para os atributos da classe, como por exemplo "null" para string e "0" para valores do tipo numérico(int, float, double, decimal).

Uso
-----

A nível de exemplo podemos utilizar a classe "Pessoa" com um atributo "Nome", podemos criar um construtor nessa classe para que no momento da criação do objeto, seja informado o nome da pessoa. Para criar um construtor em c# a sintaxe é <ModeficadorDeAcesso> <NomeDaClasse>(/*Parametros*/){}. Visto que o construtor é um método/comportamento da classe que deve ficar visível à outras classes, o modificador de acesso sempre deve ser definido como "Public". Como podemos observar na sintaxe os construtores não necessitam de um tipo de retorno para o método, pois sua função é exclusivamente imputar dados aos atríbutos da classe. Para a classe pessoa que citamos, o código ficaria da seguinte forma:

- Exemplo de uma classe Pessoa:

```csharp
	class Pessoa
	{
   		string Nome;
   
   		/*Esse é um exemplo de construtor*/	
   		public Pessoa(string nome)
   		{
  			Nome = nome;
   		}
	}
```

- Observação importante.: Ao criar um construtor, será obrigatório informar os dados de entrada da classe na criação do objeto. Para situações em que não é necessário informar os dados na instanciação do objeto, podemos criar um construtor "vazio" ou até mesmo criar mais de um construtor definindo quais parametros de instanciação cada um deve receber. Ao ato de termos mais de construtor na classe, podemos chamar de sobre carga de construtores. A modelagem de um ou mais construtores deve ser analisada de acordo com o problema ao qual prende-se resolver. Abaixo exemplo da classe Pessoa, contendo um construtor vázio e construtores com parametros:

```csharp
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

        /*Construtor da classe Pessoa, recebendo parametros para todos os atributos da classe*/
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
```

- Exemplo da instancia da classe Pessoa utilizando um construtor vazio:  


```csharp
            Pessoa pessoa1 = new Pessoa();

            pessoa1.Nome = "Paulo";
            pessoa1.Idade = 45;
            pessoa1.Genero = "Masculino";
            pessoa1.Identificar();
``` 

- Exemplo da instancia da classe Pessoa utilizando um construtor contendo parametros:  


```csharp
            Pessoa pessoa2 = new Pessoa("Paulo",45, "Masculino");
            pessoa2.Identificar();
``` 

Exemplo simples utilizando uma classe conta bancária:
--------

- Criação e definição da classe, com atríbutos e comportamentos:

 ```csharp
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
```

- Instância de um objeto do tipo ContaBancaria, atribuição de valores no objeto e utilização dos comportamentos do objeto:

```csharp
            ContaBancaria conta = new ContaBancaria("João Batista");
            conta.Depositar(100);
            conta.Sacar(50);
            conta.MostrarDetalhes();
```

Referências
-----
<p>Udemy Macoratti:  https://www.udemy.com/course/c-aplicando-principios-solid-na-pratica/learn/lecture/19240560#overview</p>
<p>Livro: André Carlucci, Carlos dos Santos, Claudenir C.Andrade, Rafael Almeida Santos. C# PARA INICIANTES desenvolvendo seu primeiro progama. 2021 Versão Digital</p>
