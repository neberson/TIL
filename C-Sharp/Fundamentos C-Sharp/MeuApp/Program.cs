namespace MeuApp;
class Program
{
    static void Main(string[] args)
    {

        //TiposDeDados();
        //ConversaoDeTipos();
        //Operadores();
        //OperadorCondicionalIf();
        //OperadorCondicionalSwitch();
        //LacoFor();
        //LacoWhile();
        //LacoDo();
        //EstudoSobreMetodos();
        //TiposPorValor();
        //TiposPorReferencia();
        EstudoSobreStructsEEnumeradores();
    }

    static void TiposDeDados()
    {
        /*-------------Byte------------------------*/
        byte meuByte = 127; // 8-bit de 0 até 255
        sbyte meuSByte = -127; // 8-bit de -128 até 127

        /*-------------Números Inteiros------------------------*/
        short meuShort = 32000; // 16-bit de -32.768 até 32.767
        ushort meuUShort = 15000; // 16-bit de 0 até 65.535
        int meuInt = 170000; // 32-bit de -2.147.483.648 até 2.147.483.647
        uint meuUInt = 200000; // 32-bit de 0 até 4.294.967.295
        long meuLong = 2500000; // 64-bit de -9.223.372.036.854.775.808 até 9.223.372.036.854.775.807
        ulong meuULong = 300000; // 64 bit de 0 até 18.446.744.073.709.551.615

        /*-------------Números Reais------------------------*/
        float meuFloat = 10.2f; /* 32-bit de -3.402823e38 até 3.402823e38*/
        double meuDouble = 10.2; /* 64-bit de -1.79769313486232e308 até 1.79769313486232e308*/
        decimal meuDecimal = 10.2m; /* 128-bit de 1.0 x 10e-28 até 7.9x10e28 */

        /*------------Valores Boolianos (true ou false)*/
        bool usuarioJaCadastrado = true; /* 8-bit aceita apenas os valores true ou false*/

        char unicoCaractere = 'A'; /* 16-bit Aceita apenas um caractere no formato Unicode*/

        string variosCaracteres = "Dev Junior"; /**/
    }

    static void ConversaoDeTipos()
    {
        /*------------------- conversão de tipos----------------------------*/
        int inteiro = 100;
        float real = 25.5f;

        real = inteiro; //100.0f
        inteiro = (int)real;

        string valorReal = real.ToString();
        inteiro = int.Parse(valorReal);

        Console.WriteLine(inteiro);
    }

    static void Operadores()
    {
        int x = 2;
        x = 2 / 2;
        Console.WriteLine(x);

        double y = 2;
        y = 2 + 2 * 2;
        Console.WriteLine(y);

        y = (2 + 2) * 2;
        Console.WriteLine(y);

        x += 3;
        Console.WriteLine(x);

        x -= 3;
        Console.WriteLine(x);

        x *= 3;
        Console.WriteLine(x);

        x -= 3;
        Console.WriteLine(x);

        x++;
        Console.WriteLine(x);

        x--;
        Console.WriteLine(x);

        Console.WriteLine(x != 25);
        Console.WriteLine(x > 25);
        Console.WriteLine(x < 25);
        Console.WriteLine(x >= 25);
        Console.WriteLine(x <= 25);
    }

    static void OperadorCondicionalIf()
    {
        int idade = 18;
        int maiorIdade = 21;
        int idadeMaxima = 65;
        if (idade >= maiorIdade && idadeMaxima < 65)
        {
            Console.WriteLine("É diferente");
        }
        else
        {
            Console.WriteLine("É igual");
        }

        Console.WriteLine("Finalizou o programa");
    }

    static void OperadorCondicionalSwitch()
    {
        string valor = "andre";

        switch (valor)
        {
            case "joao": Console.WriteLine("Não é o cara!"); break;
            case "marcelo": Console.WriteLine("Não é o cara!"); break;
            case "andre": Console.WriteLine("É este!"); break;
            default: Console.WriteLine("Não encontrei"); break;
        }

    }

    static void LacoFor()
    {
        for (int i = 0; i <= 5; i++)
        {
            Console.WriteLine(i);
        }
    }

    static void LacoWhile()
    {
        int i = 0;

        while (i <= 5)
        {
            Console.WriteLine(i);
            i++;
        }
    }

    static void LacoDo()
    {
        int valor = 0;

        do
        {
            Console.WriteLine(valor);
            valor++;
        } while (valor <= 5);
    }

    static void EstudoSobreMetodos()
    {
        //Invocação do método
        MeuMetodo("C# é legal");
        string nome = RetornaNome("Neberson", "Andrade");

        Console.WriteLine(nome);

        MetodoComParametroOpcional();
        MetodoComParametroOpcional(38);
    }

    // Definição do método
    static void MeuMetodo(string parametro)
    {
        Console.WriteLine(parametro);
    }

    // Definição do método
    // Retorna uma string e recebe vários parâmetos
    static string RetornaNome(string nome, string sobrenome)
    {
        return nome + " " + sobrenome;
    }

    static string MetodoComParametroOpcional(int idade = 27)
    {
        return "O parametro idade é opcional o valor 27 definido como padrão!";
    }

    static void TiposPorValor()
    {
        int x = 25;
        int y = x;

        Console.WriteLine(x);
        Console.WriteLine(y);

        x = 32;
        Console.WriteLine(x);
        Console.WriteLine(y);
    }

    static void TiposPorReferencia()
    {
        var arr = new string[2];
        arr[0] = "Item 1";

        var arr2 = arr;

        Console.WriteLine(arr[0]);
        Console.WriteLine(arr2[0]);

        arr[0] = "Item 2";
        Console.WriteLine(arr[0]);
        Console.WriteLine(arr2[0]);
    }

    static void EstudoSobreStructsEEnumeradores()
    {
        Product mouse = new Product(1, "Mouse gamer", 299.97, EProductType.Product);
        Product manutencaoEletrica = new Product(2, "Manutenção elétrica residencial", 500, EProductType.Service);

        Console.WriteLine(mouse.Id);
        Console.WriteLine(mouse.Name);
        Console.WriteLine(mouse.Type);
        Console.WriteLine((int)mouse.Type);
        Console.WriteLine(mouse.Price);

        double PriceInDolar = mouse.PriceInDolar(4.84);

        Console.WriteLine(PriceInDolar);


        mouse.Id = 55;

        Console.WriteLine(mouse.Id);

    }


}

struct Product
{
    public int Id;
    public string Name;
    public double Price;
    public EProductType Type;
    public Product(int id, string name, double price, EProductType type)
    {
        Id = id;
        Name = name;
        Price = price;
        Type = type;
    }

    public double PriceInDolar(double dolar)
    {
        return Price / dolar;
    }
}

enum EProductType
{
    Product = 1,
    Service = 2
}