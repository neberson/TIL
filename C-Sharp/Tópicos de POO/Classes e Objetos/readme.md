Classes e Objetos
==========
Classes na orientação a objetos é uma forma de abstração de objetos do mundo real em programação. Elas descrevem de uma forma computacional quais os dados e comportamentos um determinado processo contém. De forma mais simples podemos definir uma classe como um molde que descreve um objeto. É como um "modelo de papel" que mostra como os objetos são, e o que eles podem fazer.

Objetos são tipos de referência da memória do computador, onde está contido os dados da classe, para interpretação e execução. Seguindo o exemplo a cima, após a criação do molde, podemos utiliza-lo para criar vários objetos "reais" que têm as mesmas características e comportamentos. É como fazer um bolo usando uma receita: a receita é a classe e o bolo é um objeto criado a partir dela. O ato de criação de objetos denominamos "instância da classe".

Como exemplo de classe na programação, podemos ter uma classe chamada "Pessoa" e nela definir atributos como Nome, CPF, Data de Nascimento, etc. Após definir os atríbutos da pessoa podemos definir os comportamentos, que poderiam ser andar, correr, saltar, etc.

Uso
-----
Conforme mencionado podemos utilizar a classe para definir um objeto do mundo real, como exemplo podemos ter uma classe chamada "Pessoa" e nela definir atributos como Nome, CPF, Data de Nascimento, etc. Após definir os atributos da pessoa podemos definir os comportamentos, que poderiam ser andar, correr, saltar, etc.

Para definir uma classe em c# utlizamos a palavra reservada "class" e em seguida o nome do objeto que queremos abstrair, entre chaves "{}" deverá ser inserido todos os atríbutos e comportamentos da classe.

- Exemplo de uma classe Pessoa:

```csharp
    class Pessoa
    {
        //definição dos campos/atributos da classe
        public string nome;
        public int idade;
        public string genero;

        //metodo que reflete um comportamento para a classe, que neste caso seria imprirmir na tela as informações da pessoa
        public void Identificar()
        {
            System.Console.WriteLine($"Olá, sou o {nome} tenho {idade} e sou do sexo {genero}");
        } 
    }
```

Após criar a classe podemos instanciar na memória do computador o objeto contendo os atributos e comportamentos da classe. Para instanciar o objeto em c# devemos especificar o tipo do objeto, definir um nome para o objeto, seguido do sinal de atribuição "=" e da palavra reservada "new", após o new utiliza-se o nome da classe novamente seguido de parenteses. A sintaxe ficaria assim: NomeDaClasse NomeDoObjeto = new NomeDaClasse(). Nas novas versões do c# é possível criar a instância sem a redundância do nome da classe, utilizando a sintaxe: NomeDaClasse NomeDoObjeto = new().


- Exemplo de instancia da classe Pessoa:

```csharp
     Pessoa pessoa1 = new Pessoa();
```
- Após a instanciar o objeto, podemos acessar o seus atríbutos e definir os valores de cada atributo. No exemplo abaixo acessamos os atríbutos do objeto "pessoa1"  e definimos os valores para nome, idade e genero. 

- Exemplo de acesso aos atríbutos da classe:  


```csharp
     pessoa1.nome = "Paulo";
     pessoa1.idade = 45;
     pessoa1.genero = "Masculino";
``` 

- Podemos também acessar os comportamentos do objeto, no exemplo abaixo acessamos o comportamento Identificar para imprimir os dados da pessoa na tela:

```csharp
     pessoa1.nome = "Paulo";
     pessoa1.idade = 45;
     pessoa1.genero = "Masculino";
```

Exemplo simples utilizando uma conta bancária:
--------

- Criação e definição da classe, com atríbutos e comportamentos:

 ```csharp
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
```

- Instância de um objeto do tipo ContaBancaria, atribuição de valores no objeto e utilização dos comportamentos do objeto:

```csharp
      ContaBancaria conta = new ContaBancaria();
      conta.NomeDoTitular = "João Figo";
      conta.Depositar(100);
      conta.MostrarDetalhes();
```

Referências
-----
Udemy Macoratti:  (https://www.udemy.com/course/c-aplicando-principios-solid-na-pratica/learn/lecture/19240554#overview)
youtube Fredi: Fredi (https://www.youtube.com/watch?v=0-gG7jWC7_U)
Livro: C# PARA INICIANTES desenvolvendo seu primeiro progama
