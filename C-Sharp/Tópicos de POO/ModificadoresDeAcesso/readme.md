Modificadores de Acesso
==========
Na programação orientada a objetos, os modificadores de acesso são utilizados para controlar a visibilidade e acessibilidade dos membros de uma classe, como atributos e métodos. Esses modificadores determinam se os membros podem ser acessados a partir de outras partes do código ou se são restritos a serem utilizados somente dentro da própria classe.

Existem diferentes modificadores de acesso em C# que podem ser aplicados a classes e objetos. Vamos discutir alguns dos principais:

1. Public
-----

O modificador de acesso "public" permite que os membros de uma classe sejam acessados de qualquer lugar no código, inclusive de outras classes e objetos. Isso significa que os membros públicos são visíveis e podem ser utilizados por qualquer parte do programa.

- Exemplo de uma classe Pessoa com atributos públicos:

```csharp
public class Pessoa
{
    public string nome;
    public int idade;
    public string genero;

    public void Identificar()
    {
        Console.WriteLine($"Olá, sou o {nome}, tenho {idade} anos e sou do sexo {genero}.");
    }
}
```

2. Private
-----

O modificador de acesso "private" restringe o acesso aos membros da classe somente ao seu próprio escopo. Isso significa que os membros privados só podem ser acessados e utilizados dentro da própria classe em que foram declarados. Outras classes ou objetos não têm acesso direto a esses membros.

- Exemplo de uma classe Pessoa com atributos privados e métodos públicos para acessá-los:

```csharp
public class Pessoa
{
    private string nome;
    private int idade;
    private string genero;

    public void SetNome(string novoNome)
    {
        nome = novoNome;
    }

    public string GetNome()
    {
        return nome;
    }

    public void SetIdade(int novaIdade)
    {
        idade = novaIdade;
    }

    public int GetIdade()
    {
        return idade;
    }

    public void SetGenero(string novoGenero)
    {
        genero = novoGenero;
    }

    public string GetGenero()
    {
        return genero;
    }

    public void Identificar()
    {
        Console.WriteLine($"Olá, sou o {nome}, tenho {idade} anos e sou do sexo {genero}.");
    }
}
```

3. Protected
-----

O modificador de acesso "protected" permite que os membros da classe sejam acessados pela própria classe e pelas classes derivadas (herdeiras) da classe em que foram declarados. Os membros protegidos não podem ser acessados por outras classes fora da hierarquia de herança.

- Exemplo de uma classe Pessoa com atributos protegidos:

```csharp
public class Pessoa
{
    protected string nome;
    protected int idade;
    protected string genero;

    public void Identificar()
    {
        Console.WriteLine($"Olá, sou o {nome}, tenho {idade} anos e sou do sexo {genero}.");
    }
}
```

4. Protected Internal:
-----

O modificador de acesso "protected internal" combina as restrições do modificador "protected" e "internal". Os membros marcados como "protected internal" podem ser acessados dentro do mesmo assembly e por classes derivadas (herdeiras) da classe, mesmo que estejam em assemblies diferentes.

- Exemplo de uma classe Pessoa com atributos protegidos internos:

```csharp
public class Pessoa
{
    protected internal string nome;
    protected internal int idade;
    protected internal string genero;

    public void Identificar()
    {
        Console.WriteLine($"Olá, sou o {nome}, tenho {idade} anos e sou do sexo {genero}.");
    }
}
```

5. Public
-----

O modificador de acesso "private protected" combina as restrições do modificador "private" e "protected". Os membros marcados como "private protected" só podem ser acessados dentro do mesmo assembly e por classes derivadas (herdeiras) da classe em que foram declarados.

- Exemplo de uma classe Pessoa com atributos privados protegidos:

```csharp
public class Pessoa
{
    private protected string nome;
    private protected int idade;
    private protected string genero;

    public void Identificar()
    {
        Console.WriteLine($"Olá, sou o {nome}, tenho {idade} anos e sou do sexo {genero}.");
    }
}
```

<p> 
Os modificadores de acesso são ferramentas importantes para encapsular e controlar o acesso aos membros de uma classe. Eles permitem definir a visibilidade adequada para cada membro, protegendo a integridade dos dados e fornecendo uma interface clara para interagir com os objetos. Ao utilizar corretamente esses modificadores, é possível desenvolver classes e objetos mais robustos e seguros.
<p>

Referências
-----
<p>Udemy Macoratti:  https://www.udemy.com/course/c-aplicando-principios-solid-na-pratica/learn/lecture/19240560#overview</p>
