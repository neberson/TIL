using System;

namespace MyAppArrays;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //DeclarandoArray();
        //PercorrendoArray();
        //PercorrendoArrayComForEach();
        AlterandoValores();
    }

    static void DeclarandoArray()
    {
        //array não inicilizado na declaração
        int[] meuArray = new int[5];
        meuArray[0] = 12;
        Console.WriteLine(meuArray[0]);

        //array inicializado na declaração
        var meuArray2 = new int[3] { 25, 22, 23 };
        Console.WriteLine(meuArray2[0]);
        Console.WriteLine(meuArray2[1]);
        Console.WriteLine(meuArray2[2]);
    }

    static void PercorrendoArray()
    {
        var meuArray = new int[3] { 25, 22, 23 };

        for (var index = 0; index < meuArray.Length; index++)
        {
            Console.WriteLine(meuArray[index]);
        }
    }

    static void PercorrendoArrayComForEach()
    {
        var meuArray = new int[3] { 25, 22, 23 };

        foreach (var item in meuArray)
        {
            Console.WriteLine(item);
        }

        var funcionarios = new Funcionario[5];
        funcionarios[0] = new Funcionario() { Id = 2579 };

        foreach (var funcionario in funcionarios)
        {
            Console.WriteLine(funcionario.Id);
            Console.WriteLine(funcionario.Nome);
        }
    }

    public struct Funcionario
    {
        public int Id { get; set; }
        public String Nome { get; set; }
    }

    static void AlterandoValores()
    {
        //Ao fazer um cópia sem criar o segundo array sem new, será cópiada a referência e não os valores
        var arr = new int[4];
        var arrb = arr;

        arr[0] = 23;
        Console.WriteLine(arrb[0]);

        //Ao fazer um cópia sem criar o segundo array com new, será cópiada os valores
        var primeiro = new int[4];
        var segundo = new int[4];

        segundo[0] = primeiro[0];

        arr[0] = 23;
        Console.WriteLine(arrb[0]);
    }
}
