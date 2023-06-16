using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ImplmentandoGuid();
            //ConcatenarStrings();
            CompracaoDeTextos();
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
        static void ConcatenarStrings()
        {
            var price = 10.2;

            //Concatenação
            var text = "O preço do produto é " + price + " apenas na promoção";
            Console.WriteLine(text);

            //Placeholders
            var text2 = string.Format("O preço do produto é {0} apenas na promoção", price);
            Console.WriteLine(text2);

            //Interpolação
            var text3 = $"O preço do produto é {price} apenas na promoção";
            Console.WriteLine(text3);
        }

        static void CompracaoDeTextos()
        {
            var texto = "Testando";

            //CompareTo compara o valor passado por parametro com a string, por padrão utiliza case sensitive
            Console.WriteLine(texto.CompareTo("Testando"));

            texto = "Esse texto é teste";

            //Contains verifica se o valor passado por parametro está contigo na string, por padrão utiliza case sensitive
            Console.WriteLine(texto.Contains("teste"));

            texto = "Esse texto é teste";

            //StringComparison.OrdinalIgnoreCase utilizado para ignorar o case sensitive
            Console.WriteLine(texto.Contains("TESTE", StringComparison.OrdinalIgnoreCase));
        }
    }
}