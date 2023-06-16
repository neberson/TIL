using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ImplmentandoGuid();
        }

        static void ImplmentandoGuid()
        {
            //Gera sempre um guid único
            var id = Guid.NewGuid();

            //Pode-se realizar a conversão de um tipo Guid para String
            id.ToString();

            //Instância um objeto do tipo Guid com os valores informados
            id = new Guid("74f942f0-6a83-4e46-9470-0d68442763a4");

            Console.WriteLine(id);

            //Cria um guid com todas as posições zeradas
            id = new Guid();
            Console.WriteLine(id);
        }
    }
}