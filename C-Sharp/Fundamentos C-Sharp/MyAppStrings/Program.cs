using System;

namespace MyAppStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //ImplmentandoGuid();
            //ConcatenarStrings();
            //CompracaoDeTextos();
            //VerificaInicioString();
            //VerificaFinalString();
            //VerificarStringIgual();
            //VerificaPosicaoDeUmItem();
            //MetodosAdicionais();
            ManipulacaoString();
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

        static void VerificaInicioString()
        {
            var texto = "Este texto é um teste";
            //StartsWith verifica se o valor informado por parametro está no inicio da string, utiliza case sensitive
            Console.WriteLine(texto.StartsWith("Este"));
            Console.WriteLine(texto.StartsWith("este"));
            Console.WriteLine(texto.StartsWith("texto"));
        }

        static void VerificaFinalString()
        {
            var texto = "Este texto é um teste";
            //EndsWith verifica se o valor informado por parametro está no final da string, utiliza case senstive
            Console.WriteLine(texto.EndsWith(" Este"));
            Console.WriteLine(texto.EndsWith("este"));
            Console.WriteLine(texto.EndsWith("texto"));
        }
        static void VerificarStringIgual()
        {
            var texto = "Este texto é um teste";
            //Equals verificar se o valor passado por parametro é EXATAMENTE igual a string
            Console.WriteLine(texto.Equals("Este texto é um teste"));

            //StringComparison.OrdinalIgnoreCase ignora o case senstive
            Console.WriteLine(texto.Equals("este texto é um teste", StringComparison.OrdinalIgnoreCase));
        }
        static void VerificaPosicaoDeUmItem()
        {
            var texto = "Este texto é um teste";
            //IndexOf retorna a posição do valor informado dentro de uma string
            Console.WriteLine(texto.IndexOf("teste"));
            Console.WriteLine(texto.IndexOf("é"));

            //LastIndexOf retorna a última ocorrência encontrada
            Console.WriteLine(texto.LastIndexOf("e"));
        }

        static void MetodosAdicionais()
        {
            var texto = "Este texto é um teste";

            //Converter todo o texto para minusculo
            Console.WriteLine(texto.ToLower());

            //Converter todo o texto para maiusculo
            Console.WriteLine(texto.ToUpper());

            //Função que vem das listas e é utilizado para inserir valor em uma posição da string
            Console.WriteLine(texto.Insert(5, "AQUI"));

            //Remove uma quantidade de caracteres a partir de uma posição da string
            Console.WriteLine(texto.Remove(5, 5));

            //Retorna a quantidade de caractares que tem uma string
            Console.WriteLine(texto.Length);
        }

        static void ManipulacaoString()
        {
            var texto = " Este texto é um teste ";
            //Percorre a string substituindo das ocorrencias do primeiro valor, pelo segundo valor. 
            Console.WriteLine(texto.Replace("e", "X"));

            //Utiliza um separador para quebrar a string em vários pedaços menores
            var divisao = texto.Split(" ");

            Console.WriteLine(divisao[0]);
            Console.WriteLine(divisao[1]);
            Console.WriteLine(divisao[2]);
            Console.WriteLine(divisao[3]);
            Console.WriteLine(divisao[4]);

            //Retorna uma quantidade de caracteres a partir de uma posição informada
            var resultado = texto.Substring(5, 5);

            Console.WriteLine(resultado);

            //Remove espaços no inicio e no final de uma string
            Console.WriteLine(texto.Trim());
        }
    }
}